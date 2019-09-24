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

namespace VEGAACABLE
{
    public partial class Home : UserControl
    {
        private readonly VegaContext _vegaContext = new VegaContext();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //-- --//
            //var expences = _vegaContext.Expences.Sum(c => c.Payment);
            //var purchases = _vegaContext.ImportingInvoices.Sum(c => c.Price);
            //var sellings = _vegaContext.SellingInvoices.Sum(c => c.Price);
            //var balance = sellings - expences - purchases;
            //lblBalance.Text = balance.ToString();
            //lblExpence.Text = expences.ToString();
            //lblSelling.Text = sellings.ToString();
            //lblPrchse.Text = purchases.ToString();


        }
    }
}
