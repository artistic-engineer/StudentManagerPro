<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="UpLoadImage.aspx.cs" Inherits="StudentManagerPro.Students.UpLoadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //Check whether user has already chosen photo
        function CheckChoseImage() {
            var fulimage = document.getElementById("<%=fulStuImage.ClientID%>");
            if (fulimage.value == "") {
                alert("Please choose photo");
                return false;
            } else return true;
        }
        //Check whether uploaded img is suitable for the request
        function CheckImg(fileUpload) {
            var fulvalue = fileUpload.value;
            fulvalue = fulvalue.toLowerCase().substr(fulvalue.lastIndexOf("."));
            if (fulvalue != ".jpg") {
                fileUpload.value = "";
                alert("Photo must be .jpg");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="StuInfoTable">
        <caption>
            第二步：上传学员照片</caption>     
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="fulStuImage" onchange="CheckImg(this)" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpLoadImage"
                    runat="server" OnClientClick="return CheckChoseImage()"
                    Text="上传照片" OnClick="btnUpLoadImage_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
