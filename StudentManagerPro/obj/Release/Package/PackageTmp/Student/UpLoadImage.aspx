<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="UpLoadImage.aspx.cs" Inherits="StudentManagerPro.Students.UpLoadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
      //检查用户是否选择照片
      function CheckChoseImage() {
          var fulImage = document.getElementById("<%=fulStuImage.ClientID %>");
          if (fulImage.vaule == "") {
              alert("请首先选择照片！");
              return false;
          } else return true;
      }
      //检查上传的照片格式是否符合.png要求
      function CheckImg(fileUpload) {
          var fulvalue = fileUpload.value;
          fulvalue = fulvalue.toLowerCase().substr(fulvalue.lastIndexOf("."));
          if (fulvalue != ".png") {
              fileUpload.value = "";
              alert("上传照片仅支持png格式！");
          } else {
              //同步显示选择的照片
              var stuImage = document.getElementById("<%=stuImage.ClientID %>");
              stuImage.src = fileUpload.value;
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
                <asp:Image ID="stuImage" runat="server" Height="128px" Width="116px" ImageUrl="~/Images/defaultImg.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="fulStuImage" onchange="CheckImg(this)"  runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpLoadImage"  
                runat="server"  OnClientClick="return CheckChoseImage() "
                    Text="上传照片" OnClick="btnUpLoadImage_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
