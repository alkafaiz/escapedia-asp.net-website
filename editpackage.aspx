<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="editpackage.aspx.cs" Inherits="XML_ASSIGNMENT.editpackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Edit Package</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="uppercase">Edit Package</h3>
                    <hr>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <h4>Package ID</h4>
                </div>
                <div class="col-md-8">
                    <h4>
                        <asp:TextBox ID="txtID" runat="server" Enabled="false" Text=""></asp:TextBox></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Title</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:TextBox ID="txtTitle" runat="server" Text=""></asp:TextBox></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Destination</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:TextBox ID="txtDest" runat="server" Text=""></asp:TextBox></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Description</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Duration</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <div class="col-lg-8">
                            <h4>
                                <asp:TextBox ID="txtDur" runat="server" Text="" TextMode="Number"></asp:TextBox></h4>
                        </div>
                    </h4>
                    days
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Type</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:DropDownList ID="txtType" runat="server">
                            <asp:ListItem>Personal</asp:ListItem>
                            <asp:ListItem>Group</asp:ListItem>
                        </asp:DropDownList>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Price</h4>
                </div>
                <div class="col-lg-8">
                    <h4>RM
                        <asp:TextBox ID="txtPrice" runat="server" Text="" TextMode="Number"></asp:TextBox></h4>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnCancel" CssClass="btn-white" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnDelete" CssClass="btn-white" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                </div>
            </div>
            <div class="row">
                <asp:PlaceHolder ID="alert1" runat="server"></asp:PlaceHolder>
            </div>
            <div class="row">
                <asp:LinkButton ID="btnMockUp" runat="server" OnClick="btnMockUp_Click">Create mockup transaction data of this package.</asp:LinkButton>
            </div>

        </div>
    </section>
</asp:Content>
