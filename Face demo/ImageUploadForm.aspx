<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadForm.aspx.cs" Inherits="Face_demo.ImageUploadForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        .style1  
        {  
            width: 281px;  
        }  
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <table style="width:100%;">  
            <tr>  
                <td class="style1">  
                     </td>  
                <td>  
                     </td>  
                <td>  
                     </td>  
            </tr>  
            <tr>  
                <td class="style1">  
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="211px" />  
 </td>  

            </tr>  
            <tr>  
                <td class="style1">  
                    <asp:Label ID="Label1" runat="server"></asp:Label>  
                </td>   
            </tr>  
            <tr>  
                <td class="style1">  
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" />  
                </td>   
            </tr>  
        </table>  
      
    </div>  
    </form>  
</body>  
</html>  
