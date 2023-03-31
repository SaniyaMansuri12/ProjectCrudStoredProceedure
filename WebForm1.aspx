<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CollegeRegistrationWithCruDStoredProcedure.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>GridView Crud Operations using Stored Procedure in ASP.Net</title>  
  
    <style type="text/css">  
        .GridviewDesign {  
            font-size: 100%;  
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;  
            color: #303933;  
        }  
          
        .headerstyleForGrid {  
            color: #FFFFFF;  
            border-right-color: #abb079;  
            border-bottom-color: #abb079;  
            background-color: #df5015;  
            padding: 0.5em 0.5em 0.5em 0.5em;  
            text-align: center;  
        }  
        .auto-style1 {
            margin-left: 90px;
            margin-top: 27px;
        }
    </style>  
  
</head>  
  
<body>  
  
    <form id="form1" runat="server">  
  
        <div class="GridviewDesign" style="font-size: large">  
  
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; College Details Form  
  
            <asp:GridView runat="server" ID="gvDetailsForCurdOperation" ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CollageId,Collagename" OnPageIndexChanging="gvDetailsForCurdOperation_PageIndexChanging" OnRowCancelingEdit="gvDetailsForCurdOperation_RowCancelingEdit" OnRowEditing="gvDetailsForCurdOperation_RowEditing" OnRowUpdating="gvDetailsForCurdOperation_RowUpdating" OnRowDeleting="gvDetailsForCurdOperation_RowDeleting" OnRowCommand="gvDetailsForCurdOperation_RowCommand" Height="377px" Width="759px" CssClass="auto-style1">  
  
                <HeaderStyle CssClass="headerstyleForGrid" />  
  
                <Columns>  
  
                    <asp:BoundField DataField="CollageId" HeaderText="Collage Id" ReadOnly="true" >  
  
                    <FooterStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
  
                    <asp:TemplateField HeaderText="Collage Name">  
  
                        <ItemTemplate>  
  
                            <asp:Label ID="lblCollagename" runat="server" Text='<%# Eval("Collagename")%>' />  
  
                        </ItemTemplate>  
  
                        <EditItemTemplate>  
  
                            <asp:TextBox ID="txtCollagename" runat="server" Text='<%# Eval("Collagename")%>' />  
  
                        </EditItemTemplate>  
  
                        <FooterTemplate>  
  
                            <asp:TextBox ID="txtpname" runat="server" placeholder="Please Enter College name " />  
                            
                        </FooterTemplate>  
  
                        <ItemStyle HorizontalAlign="Center" />
  
                    </asp:TemplateField>  
  
                    <asp:TemplateField HeaderText="Collage Rank">  
  
                        <ItemTemplate>  
  
                            <asp:Label ID="lblCollageRank" runat="server" Text='<%# Eval("CollageRank")%>'></asp:Label>  
  
                        </ItemTemplate>  
  
                        <EditItemTemplate>  
  
                            <asp:TextBox ID="txtCollageRank" runat="server" Text='<%# Eval("CollageRank")%>' />  
  
                        </EditItemTemplate>  
 
                        <FooterTemplate>  
                        <asp:TextBox ID="txtprice" runat="server" placeholder="Please Enter College Rank"/>  
                           <%-- <asp:TextBox ID="txtCollageRank" runat="server" />  --%>
  
                            <asp:Button ID="btnAddNewItem" CommandName="AddNew" runat="server" Text="Add" />  
  
                        </FooterTemplate>  
  
                        <ItemStyle HorizontalAlign="Center" />
  
                    </asp:TemplateField>  
  
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" >  
  
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
  
                </Columns>  
  
            </asp:GridView>  
  
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
  
            <asp:Label ID="lblresult" runat="server"></asp:Label>  
  
        </div>  
  
    </form>  
  
</body>  
  
</html>
