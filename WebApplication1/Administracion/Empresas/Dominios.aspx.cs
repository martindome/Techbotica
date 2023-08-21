using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion.Empresas
{
    public partial class Dominios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDomainsGrid();
            }
        }

        private void BindDomainsGrid()
        {
            // Create a DataTable object and add columns to it
            DataTable dt = new DataTable();
            dt.Columns.Add("DomainSuffix");
            dt.Columns.Add("Delete");

            // Add dummy data to the DataTable
            DataRow _ravi = dt.NewRow();
            _ravi["DomainSuffix"] = "@example.com";
            dt.Rows.Add(_ravi);

            _ravi = dt.NewRow();
            _ravi["DomainSuffix"] = "@anotherexample.com";
            dt.Rows.Add(_ravi);

            _ravi = dt.NewRow();
            _ravi["DomainSuffix"] = "@sometestdomain.com";
            dt.Rows.Add(_ravi);

            // Bind the DataTable to the GridView
            DomainsGrid.DataSource = dt;
            DomainsGrid.DataBind();
        }
    }
}