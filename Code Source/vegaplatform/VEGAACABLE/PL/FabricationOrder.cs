using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL;

namespace VEGAACABLE.PL
{
    public partial class FabricationOrder : UserControl
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new VegaContext());
        public FabricationOrder()
        {
            InitializeComponent();
        }

        private void FabricationOrder_Load(object sender, EventArgs e)
        {
            RefreshFO();
            RefreshSeq();
            RefreshRM();
        }

        private void BtnLaunch_Click(object sender, EventArgs e)
        {
            if (dgvFabOrders.RowCount > 0)
            {
                var fo = _unitOfWork.FabricationOrder.Find(Convert.ToInt32(dgvFabOrders.CurrentRow.Cells[0].Value));
                if (fo.Status == BL.Domain.FabricationOrder.stat.Pending)
                {
                    DialogResult dr = MessageBox.Show("Would You Confirm The Operation ?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        fo.Status = BL.Domain.FabricationOrder.stat.Started;
                        fo.StartingDate = DateTime.Today;
                        _unitOfWork.FabricationOrder.InsertOrUpdate(fo);

                        var usedRMList = _unitOfWork.UsedRawMaterial.AllUsedRawMaterials(fo.Id).ToList();
                        foreach (var t in usedRMList)
                        {
                            var rm = _unitOfWork.RawMaterials.Find(t.RawMaterialID);
                            rm.Mass = t.Weight;
                            t.Weight = 0;

                            _unitOfWork.RawMaterials.InsertOrUpdate(rm);
                            _unitOfWork.UsedRawMaterial.InsertOrUpdate(t);

                        }

                        var seq = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(fo.NomenclatureId)
                            .GroupBy(c => c.SequenceId )
                            .Select(c => c.Key).ToList();
                        foreach (var t in seq)
                        {
                            ProgressionCheck pc = new ProgressionCheck
                            {
                                FabricationOrder = fo,
                                SeqID = t,
                                Progress = ProgressionCheck.Progression.NotStarted
                            };
                            _unitOfWork.ProgressionChecks.InsertOrUpdate(pc);
                        }

                        _unitOfWork.Complete();

                    }
                    RefreshFO();
                }
                else
                {
                    MessageBox.Show("The FO is Already in Started State !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
        }

        private void BtnCheckFO_Click(object sender, EventArgs e)
        {
            if (dgvFabOrders.RowCount > 0) {
                var fo = _unitOfWork.FabricationOrder.Find(Convert.ToInt32(dgvFabOrders.CurrentRow.Cells[0].Value));
                if (fo.Status == BL.Domain.FabricationOrder.stat.Started)
                {
                    CheckFO FO = new CheckFO(fo.Id);
                    FO.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This FO Is Yet Not Started", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (dgvFabOrders.RowCount > 0)
            {
                var fo = _unitOfWork.FabricationOrder.Find(Convert.ToInt32(dgvFabOrders.CurrentRow.Cells[0].Value));
                if (fo.Status == BL.Domain.FabricationOrder.stat.Pending)
                {
                    DialogResult dr = MessageBox.Show("Would You Confirm The Operation ?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {


                        var usedRMList = _unitOfWork.UsedRawMaterial.AllUsedRawMaterials(fo.Id).ToList();
                        foreach (var t in usedRMList)
                        {
                            var rm = _unitOfWork.RawMaterials.Find(t.RawMaterialID);
                            rm.Status = RawMaterial.RMStatus.Available;

                            _unitOfWork.RawMaterials.InsertOrUpdate(rm);
                            _unitOfWork.UsedRawMaterial.Delete(t.Id);

                        }
                        _unitOfWork.FabricationOrder.Delete(fo.Id);

                        _unitOfWork.Complete();

                    }
                    RefreshFO();
                }
                else
                {
                    MessageBox.Show("You Can't Delete This Fab Order Because Its Already started!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
        }

        private void DgvFabOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshSeq();
            RefreshRM();
        }

        private void Srch_TextChange(object sender, EventArgs e)
        {
            var foList = _unitOfWork.FabricationOrder.AllFabricationOrders()
                .Where(c => c.Id.ToString().Contains(srch.Text)
                || c.Nomenclature.Designation.Contains(srch.Text)
                || c.Length.ToString().Contains(srch.Text)
                || c.Status.ToString().Contains(srch.Text)
                || c.CreationDate.ToString().Contains(srch.Text)
                || c.StartingDate.ToString().Contains(srch.Text))
                .Select(n => new
                {
                    n.Id,
                    n.Nomenclature.Designation,
                    n.Length,
                    n.Status,
                    n.CreationDate,
                    n.StartingDate
                }).ToList();
            
                dgvFabOrders.DataSource = foList;
                dgvFabOrders.Columns[0].Width = 25;
            
        }

        public void RefreshFO()
        {
            var foList = _unitOfWork.FabricationOrder.AllFabricationOrders()
                .Select(n => new
                {
                    n.Id,
                    n.Nomenclature.Designation,
                    n.Length,
                    n.Status,
                    n.CreationDate,
                    n.StartingDate
                }).ToList();
            
                dgvFabOrders.DataSource = foList;
                dgvFabOrders.Columns[0].Width = 25;
            
        }

        public void RefreshSeq()
        {
            if (dgvFabOrders.RowCount > 0)
            {
                var foId = Convert.ToInt32(dgvFabOrders.CurrentRow.Cells[0].Value);
                var fo = _unitOfWork.FabricationOrder.SingleOrDefault(c => c.Id == foId);
                var seq = _unitOfWork.NomenclatureSequence.AllNomenclatureSequances(fo.NomenclatureId)
                    .GroupBy(c => c.Sequence.Name)
                    .Select(c => new {Sequences = c.Key}).ToList();

                dgvSeq.DataSource = seq; 
            }
            
        }

        public void RefreshRM()
        {
            if (dgvFabOrders.RowCount > 0)
            {
                var ofId = Convert.ToInt32(dgvFabOrders.CurrentRow.Cells[0].Value);
                var rm = _unitOfWork.UsedRawMaterial.AllUsedRawMaterials(ofId)
                        .Select(c => new { c.Id, Matricule = c.RawMaterial.RefNbr }).ToList();

                dgvRawM.DataSource = rm; 
            }
        }
    }
}
