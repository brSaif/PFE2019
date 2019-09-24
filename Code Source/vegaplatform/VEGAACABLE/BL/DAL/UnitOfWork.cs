using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;
using VEGAACABLE.DAL.Repositories;

namespace VEGAACABLE.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaContext _context;

        public UnitOfWork(VegaContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            Users = new UserRepository(_context);
            Supplier = new SupplierRepository(_context);
            Component = new ComponentRepository(_context);
            ImportingInvoice = new ImportingInvoiceRepository(_context);
            UGroup = new GroupsRepository(_context);
            FabricationOrder = new FabricationOrderRepository(_context);
            Expence = new ExpenceRepository(_context);
            ExpenceCat = new  ExpenceCatRepository(_context);
            GroupPermission = new  GroupPermissionRepository(_context);
            Permission = new PermissionRepository(_context);
            Sequence = new SequenceRepository(_context);
            Nomenclature = new NomenclatureRepository(_context);
            NomenclatureSequence = new NomenclatureSequenceRepository(_context);
            Color = new ColorRepository(_context);
            SellingInvoices = new SellingInvoicesRepository(_context);
            RawMaterials = new RawMaterialsRepository(_context);
            UsedRawMaterial = new UsedRawMaterialRepository(_context);
            ProgressionChecks = new ProgressionChecksRepository(_context);

        }

        public IComponentRepository Component { get; private set; }
        public INomenclatureSequenceRepository NomenclatureSequence { get; private set; }
        public INomenclatureRepository Nomenclature { get; private set; }
        public IProgressionChecksRepository ProgressionChecks { get; private set; }
        public IUsedRawMaterialRepository UsedRawMaterial { get; private set; }
        public IColorRepository Color { get; private set; }
        public IImportingInvoiceRepository ImportingInvoice { get; private set; }
        public ISellingInvoicesRepository SellingInvoices { get; private set; }
        public IGroupsRepository UGroup { get; private set; }
        public IFabricationOrderRepository FabricationOrder { get; private set; }
        public IExpenceRepository Expence { get; private set; }
        public IExpenceCatRepository ExpenceCat { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IUserRepository Users { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IGroupPermissionRepository GroupPermission { get; private set; }
        public IPermissionRepository Permission { get; private set; }
        public ISequenceRepository Sequence { get; private set; }
        public IRawMaterialsRepository RawMaterials { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
