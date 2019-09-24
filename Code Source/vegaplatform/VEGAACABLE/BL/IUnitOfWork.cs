using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.BL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IClientRepository Clients { get; }
        ISupplierRepository Supplier { get; }
        IExpenceCatRepository ExpenceCat { get; }
        INomenclatureRepository Nomenclature { get; }
        IExpenceRepository Expence { get; }
        IComponentRepository Component { get; }
        IProgressionChecksRepository ProgressionChecks { get; }
        IFabricationOrderRepository FabricationOrder { get; }
        IUsedRawMaterialRepository UsedRawMaterial { get; }
        IColorRepository Color { get; }
        IGroupsRepository UGroup { get; }
        IImportingInvoiceRepository ImportingInvoice { get; }
        ISellingInvoicesRepository SellingInvoices { get; }
        IGroupPermissionRepository GroupPermission { get; }
        IPermissionRepository Permission { get; }
        ISequenceRepository Sequence { get; }
        INomenclatureSequenceRepository NomenclatureSequence { get; }
        IRawMaterialsRepository RawMaterials { get; }

        int Complete();
    }
}
