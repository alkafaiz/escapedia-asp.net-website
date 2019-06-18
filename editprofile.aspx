<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="editprofile.aspx.cs" Inherits="XML_ASSIGNMENT.editprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Edit Profile</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
                <div class="container">
    <div class="row">
                                <div class="col-sm-12">
                                    <h3 class="uppercase">Edit Profile</h3>
                                    <hr>
                                </div>
                            </div>
                                    <div class="row">
                                        <div class="col-md-4"><h4>Vendor ID</h4></div>
                                        <div class="col-md-8"><h4>
                                            <asp:TextBox ID="TextBox1" runat="server" Enabled="false" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Username</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox2" runat="server" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Company Name</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox3" runat="server" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Address</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox4" runat="server" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>City</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox5" runat="server" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Country</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox6" runat="server" Text=""></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Email</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox7" runat="server" Text="" TextMode="Email"></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Phone</h4></div>
                                        <div class="col-lg-8"><h4><asp:TextBox ID="TextBox8" runat="server" Text="" TextMode="Number"></asp:TextBox></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></div>
                                        <div class="col-md-4">
                                        <asp:Button ID="btnCancel" CssClass="btn-white" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                        </div>
                                        <div class="col-md-4">
                                        <asp:PlaceHolder ID="alert1" runat="server"></asp:PlaceHolder>
                                        </div>
                                    </div>
                    </div>
        </section>
</asp:Content>
