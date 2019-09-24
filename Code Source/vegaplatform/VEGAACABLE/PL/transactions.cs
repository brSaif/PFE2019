using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VEGAACABLE.DAL;
using VEGAACABLE.PL;

namespace VEGAACABLE
{
    public partial class transactions : UserControl
    {
        public static int usrId;

        public transactions(int id)
        {
            usrId = id;
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            RefrechImports();
            RefrechSales();
        }

        private void BtnAddSale_Click(object sender, EventArgs e)
        {
            AddSaleInvoive m = new AddSaleInvoive(usrId, 0);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
                RefrechSales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnDelSale_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Would you Confirm the operation to delete the invoice", "Alert",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes && dgvSales.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var invoiceId = Convert.ToInt32(dgvSales.CurrentRow.Cells[0].Value);
                    _unitOfWork.SellingInvoices.Delete(invoiceId);
                    _unitOfWork.Complete(); 
                }
                RefrechSales();

            }
        }

        private void BtnAddPur_Click(object sender, EventArgs e)
        {
            AddPurchaseInvoice m = new AddPurchaseInvoice(usrId,0);
            try
            {
                m.btnAdd.Text = "Add New";
                m.ShowDialog();
                RefrechImports();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnDelPur_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Would you Confirm the operation to delete the invoice", "Alert",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes && dgvPuchases.RowCount > 0)
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var invoiceId = Convert.ToInt32(dgvPuchases.CurrentRow.Cells[0].Value);
                    _unitOfWork.ImportingInvoice.Delete(invoiceId);
                    _unitOfWork.Complete(); 
                }
                RefrechImports();

            }
        }

        private void PurchaseSearch_TextChange(object sender, EventArgs e)
        {
            using (var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var importList = _unitOfWork.ImportingInvoice.AllImportingInvoices()
                        .Where(m => m.RawMaterial.RefNbr.Contains(PurchaseSearch.Text)
                                    || m.Suplier.Company.Contains(PurchaseSearch.Text)
                                    || m.Price.ToString().Contains(PurchaseSearch.Text)
                                    || m.Discount.ToString().Contains(PurchaseSearch.Text)
                                    || m.PaymentStatus.ToString().Contains(PurchaseSearch.Text)
                                    || m.PaymentType.ToString().Contains(PurchaseSearch.Text)
                                    || m.Id.ToString().Contains(PurchaseSearch.Text)
                                    || m.CreatedDate.ToString().Contains(PurchaseSearch.Text)
                                    || m.User.UserName.ToString().Contains(PurchaseSearch.Text))
                        .Select(c => new
                        {
                            c.Id,
                            c.Suplier.Company,
                            Matricule = c.RawMaterial.RefNbr,
                            c.Price,
                            c.Discount,
                            c.PaymentType,
                            c.PaymentStatus,
                            CreatedBy = c.User.Id,
                            Date = c.CreatedDate
                        }).ToList();
                dgvPuchases.DataSource = importList; 
            }
            dgvPuchases.Columns[0].Width = 25;
        }

        private void SearchSale_TextChange(object sender, EventArgs e)
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new VegaContext()))
                {
                    var selList = _unitOfWork.SellingInvoices.AllSellingInvoices()
                                .Where(c => c.Client.Company.Contains(SearchSale.Text)
                                || c.Id.ToString().Contains(SearchSale.Text)
                                || c.FabricationOrder.Nomenclature.Designation.ToString().Contains(SearchSale.Text)
                                || c.Price.ToString().Contains(SearchSale.Text)
                                || c.Discount.ToString().Contains(SearchSale.Text)
                                || c.PaymentStatus.ToString().Contains(SearchSale.Text)
                                || c.PaymentType.ToString().Contains(SearchSale.Text)
                                || c.User.UserName.ToString().Contains(SearchSale.Text)
                                || c.CreatedDate.ToString().Contains(SearchSale.Text))
                                    .Select(c => new
                                    {
                                        c.Id,
                                        c.Client.Company,
                                        c.FabricationOrder.Nomenclature.Designation,
                                        c.Price,
                                        c.Discount,
                                        c.PaymentType,
                                        c.PaymentStatus,
                                        CreatedBy = c.User.UserName,
                                        Date = c.CreatedDate
                                    }).ToList();
                    dgvSales.DataSource = selList; 
                }
                dgvSales.Columns[0].Width = 25;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void RefrechSales()
        {
            using (var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var sales = _unitOfWork.SellingInvoices.AllSellingInvoices()
                        .Select(c => new
                        {
                            c.Id,
                            c.Client.Company,
                            c.FabricationOrder.Nomenclature.Designation,
                            c.Price,
                            c.Discount,
                            c.PaymentType,
                            c.PaymentStatus,
                            CreatedBy = c.User.UserName,
                            Date = c.CreatedDate
                        }).ToList();
                if (sales.Any())
                {
                    dgvSales.DataSource = sales;
                    dgvSales.Columns[0].Width = 25;
                } 
            }
        }

        public void RefrechImports()
        {
            using (var _unitOfWork = new UnitOfWork(new VegaContext()))
            {
                var importList = _unitOfWork.ImportingInvoice.AllImportingInvoices()
                        .Select(c => new
                        {
                            c.Id,
                            c.Suplier.Company,
                            Matricule = c.RawMaterial.RefNbr,
                            c.Price,
                            c.Discount,
                            c.PaymentType,
                            c.PaymentStatus,
                            CreatedBy = c.User.UserName,
                            Date = c.CreatedDate
                        }).ToList();
                if (importList.Any())
                {
                    dgvPuchases.DataSource = importList;
                    dgvPuchases.Columns[0].Width = 25;
                } 
            }
        }

        private void BtnUpdSale_Click(object sender, EventArgs e)
        {
            try
            {
                var sellID =  Convert.ToInt32(dgvSales.CurrentRow.Cells[0].Value);
                AddSaleInvoive m = new AddSaleInvoive(usrId, sellID);
                m.txtLength.Text = dgvSales.CurrentRow.Cells[1].Value.ToString();
                m.txtDiscount.Text = dgvSales.CurrentRow.Cells[4].Value.ToString();
                m.txtPrice.Text = dgvSales.CurrentRow.Cells[3].Value.ToString();
                m.btnAdd.Text = "Update";
                m.ShowDialog();
                RefrechSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var purID = Convert.ToInt32(dgvPuchases.CurrentRow.Cells[0].Value);
                AddPurchaseInvoice m = new AddPurchaseInvoice(usrId, purID);
                m.btnAdd.Text = "Update";
                m.ShowDialog();
                RefrechImports();
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (ex.Message);
            }
        }
    }
}
