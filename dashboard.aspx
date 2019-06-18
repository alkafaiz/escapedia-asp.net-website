<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="XML_ASSIGNMENT.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <!--<asp:Label ID="lblUser" runat="server" Visible="true" Text=""></asp:Label>-->
    <a href="#">Dashboard</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
            <section>
                <div class="container">
                    <div class="row">
                        <div class="col-md-9 col-md-push-3">                                                        
                            <div class="row">
                                <div class="col-sm-12">
                                    <h3 class="uppercase">My Profile</h3>
                                    <hr>
                                </div>
                            </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Vendor ID</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblvendorID" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Username</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblusername" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Company Name</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblCompanyName" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Address</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lbladdress" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>City</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblCity" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Country</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblCountry" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Email</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblEmail" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4"><h4>Phone</h4></div>
                                        <div class="col-lg-8"><h4><asp:label ID="lblPhone" runat="server" text=""></asp:label></h4></div>
                                    </div>
                                    <div class="row">
                                        
                                        <a class="btn" href="editprofile.aspx">Edit Profile</a>
                                        
                                    </div>

                        </div>
                        <!--end of nine col-->
                        <div class="col-md-3 col-md-pull-9 hidden-sm">
                            <div class="widget">
                                <ul class="accordion accordion-1">
                                <li class="active">
                                    <div class="title">
                                        <span>Profile</span>                                                                        
                                    </div>
                                </li>
                                <li>                                    
                                    <div class="title">
                                        <span><a href="packages.aspx">Packages</a></span>
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
