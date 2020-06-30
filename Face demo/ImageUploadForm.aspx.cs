using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Face_demo
{
    public partial class ImageUploadForm : System.Web.UI.Page
    {
        //TODO: CHANGE THIS!!!!
        public static bool UserImage = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                

                FileUpload1.SaveAs(Server.MapPath("Image//image.jpg" ));
                Label1.Text = "Image Uploaded";
                Label1.ForeColor = System.Drawing.Color.ForestGreen;
                //user image is nu true
                UserImage = true;
            }
            else
            {
                Label1.Text = "Please Select your file";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        
    }
}