<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="StudentManage.aspx.cs" Inherits="StudentManagerPro.Students.StudentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/StudentManage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="QueryDiv">
        请选择要查询的班级：<asp:DropDownList ID="ddlClass" Width="200px" runat="server" ClientIDMode="Inherit">
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="提交查询" OnClick="btnQuery_Click" />
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>

    <asp:DataList ID="dlStuInfo" runat="server" RepeatColumns="2" Height="400px" CellPadding="4" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <div class="stuInfo">
                <div class="stuImg">
                    <asp:Image ID="imgStu" runat="server" Height="150px"
                        ImageUrl='<%#Eval("StudentId","~/Images/Student/{0}.jpg") %>' Width="145px" />
                </div>
                <div class="stuItem">
                    <span>Name：</span><span style="width: 50px;"><%#Eval("StudentName") %></span>&nbsp;&nbsp;
                    <span>性别：<%#Eval("Gender") %></span></div>
                <div class="stuItem">
                    <span>班级：</span><span style="width: 50px;"><%#Eval("ClassName") %></span>&nbsp;&nbsp;
                    
                </div>
                <div class="stuItem">
                    <span>出生日期：<%#Eval("Birthday","{0:yyyy-MM-dd}") %></span></div>
                <div class="stuItem">
                    <span>家庭住址：</span><span style="width: 80px;"><%#Eval("StudentAddress")%></span></div>
                <div class="stuItem1">
                    <asp:HyperLink ID="HyperLink1" runat="server"
                        NavigateUrl='<%#Eval("StudentId","~/Student/EditStudent.aspx?Studentid={0}") %>'
                        ForeColor="Blue">修改信息</asp:HyperLink>
                    &nbsp;
                    <asp:LinkButton ID="btnDel" CommandArgument='<%#Eval("StudentId") %>' 
                        OnClientClick="return confirm('Confirm deleting?')" OnClick="btnDel_Click" runat="server">删除学员</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>

    <%--<asp:Repeater ID="rpList" runat="server">
        <ItemTemplate>
             <div class="stuInfo">
                <div class="stuImg">
                    <asp:Image ID="imgStu" runat="server" Height="150px"
                        ImageUrl='<%#Eval("StudentId","~/Images/Student/{0}.jpg") %>' Width="145px" />
                </div>
                <div class="stuItem">
                    <span>Name：</span><span style="width: 50px;"><%#Eval("StudentName") %></span>&nbsp;&nbsp;
                    <span>性别：<%#Eval("Gender") %></span></div>
                <div class="stuItem">
                    <span>班级：</span><span style="width: 50px;"><%#Eval("ClassName") %></span>&nbsp;&nbsp;
                    
                </div>
                <div class="stuItem">
                    <span>出生日期：<%#Eval("Birthday","{0:yyyy-MM-dd}") %></span></div>
                <div class="stuItem">
                    <span>家庭住址：</span><span style="width: 80px;"><%#Eval("StudentAddress")%></span></div>
                <div class="stuItem1">
                    <asp:HyperLink ID="HyperLink1" runat="server"
                        NavigateUrl='<%#Eval("StudentId","~/Student/EditStudent.aspx?Studentid={0}") %>'
                        ForeColor="Blue">修改信息</asp:HyperLink>
                    &nbsp;
                    <asp:LinkButton ID="btnDel" CommandArgument='<%#Eval("StudentId") %>' runat="server">删除学员</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>

</asp:Content>
