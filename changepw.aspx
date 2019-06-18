<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="changepw.aspx.cs" Inherits="XML_ASSIGNMENT.changepw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Change Password</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="uppercase">Change Password</h3>
                    <hr>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Existing Password</h4>
                </div>
                <div class="col-lg-8">
                    <h4><asp:TextBox ID="txtOldPw" runat="server" Text="" TextMode="Password"></asp:TextBox></h4>
                </div>
                
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>New Password</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:TextBox ID="txtNewPw" runat="server" Text="" TextMode="Password"></asp:TextBox></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Confirm New Password</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:TextBox ID="txtConfPw" runat="server" TextMode="Password"></asp:TextBox></h4>
                </div>
            </div>
            

            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnSave" runat="server" Text="Confirm" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnCancel" CssClass="btn-white" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
                <div class="col-md-4">
                <asp:PlaceHolder ID="alert1" runat="server"></asp:PlaceHolder>
                <%--<div class="alert alert-warning alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <strong>Sorry,</strong> the existing password you entered is wrong.
                            </div>--%>
                    </div>
            </div>
        </div>
    </section>
</asp:Content>
