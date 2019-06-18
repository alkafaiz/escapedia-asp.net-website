<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="packages.aspx.cs" Inherits="XML_ASSIGNMENT.packages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Packages</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
                <div class="container">
                    <div class="row">
                        <div class="col-md-9 col-md-push-3">                                                        
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-sm-9">
                                        <h3 class="uppercase">My Packages</h3>
                                    
                                    </div>
                                    <div class="col-sm-3">
                                        <a class="btn" href="createpackage.aspx">Add Package</a>                                  
                                    </div><hr>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <h3><asp:Label ID="lblNone" runat="server" Text="No Packages" Visible="false"></asp:Label></h3>
                                    <!--<asp:GridView ID="GridView1" runat="server" Width="867px"></asp:GridView>-->
                                  <!--start of packages
                                    <div class="container"> -->                                       
                                        <div class="row ">
                                            <!--<div class="col-sm-6">
                                                <div class="image-caption cast-shadow mb-xs-32">
                                                    <img alt="Captioned Image" src="img/home7.jpg" />
                                                    <div class="caption">
                                                        <p>
                                                            <strong>Package:</strong> Trip to Japan
                                                        </p>
                                                        
                                                    </div>
                                                </div><br />
                                                <a class="btn" href="#">Edit</a>
                                                <a class="btn" href="#">Delete</a>
                                            </div>-->
                                            <asp:PlaceHolder ID="packagesVendor" runat="server"></asp:PlaceHolder>
                                        </div>
                                    </div>
                           <!--end of packages-->
                                </div>
                            
                        </div>
                        <!--end of nine col-->
                        <div class="col-md-3 col-md-pull-9 hidden-sm">
                            <div class="widget">
                                <ul class="accordion accordion-1">
                                <li >
                                    <div class="title">
                                        <span><a href="dashboard.aspx">Profile</a></span>                                                                        
                                    </div>
                                </li>
                                <li class="active">                                    
                                    <div class="title">
                                        <span>Packages</span>
                                    </div>                                    
                                </li>
                                <li>                                   
                                    <div class="title">
                                        <span><a href="changepw.aspx">Change Password</a></span>
                                    </div>                                   
                                </li>
                                <li>                                    
                                    <div class="title">                                        
                                        <asp:linkbutton runat="server" OnClick="Unnamed1_Click">Logout</asp:linkbutton>
                                    </div>
                                </li>
                                </ul>
                            </div>
                            
                        </div>
                        <!--end of sidebar-->
                    </div>
                    <!--end of container row-->
                </div>
                <!--end of container-->
            </section>
</asp:Content>
