<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="insight.aspx.cs" Inherits="XML_ASSIGNMENT.insight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Insight</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="uppercase">Company Detail:
                        <asp:label id="lblCompNm" runat="server" text=""></asp:label>
                    </h3>
                    <hr>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Vendor ID</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:label id="lblvendorID" runat="server" text=""></asp:label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Company Name</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:label id="lblCompanyName" runat="server" text=""></asp:label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Address</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:label id="lbladdress" runat="server" text=""></asp:label>
                        , 
                        <asp:label id="lblCity" runat="server" text=""></asp:label>
                        , 
                        <asp:label id="lblCountry" runat="server" text=""></asp:label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <h4>Contact</h4>
                </div>
                <div class="col-lg-8">
                    <h4>
                        <asp:label id="lblPhone" runat="server" text=""></asp:label>
                        , 
                        <asp:label id="lblEmail" runat="server" text=""></asp:label>
                    </h4>
                </div>
            </div>



            <!--start insight-->
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="uppercase">Insight                        
                    </h3>
                    <hr>
                </div>
            </div>
            <div class="row">
                <asp:placeholder ID="bsinsight" runat="server"></asp:placeholder>
                <%--<div class="col-sm-6">
                    <div class="progress-bars">
                        <h5 class="uppercase">January</h5>
                        <div class="progress progress-1">
                            <div class="progress-bar" data-progress="90">
                                <span class="title">Branding</span>
                            </div>
                        </div>
                        <!--end of progress bar-->
                        <div class="progress progress-1">
                            <div class="progress-bar" data-progress="70">
                                <span class="title">E-Commerce</span>
                            </div>
                        </div>
                        <!--end of progress bar-->
                        <div class="progress progress-1">
                            <div class="progress-bar" data-progress="60">
                                <span class="title">Websites</span>
                            </div>
                        </div>
                        <!--end of progress bar-->
                        <div class="progress progress-1">
                            <div class="progress-bar" data-progress="50">
                                <span class="title">iOS Apps</span>
                            </div>
                        </div>
                        <!--end of progress bar-->
                    </div>
                    <h5 class="uppercase">Total Amount: RM 12000</h5>
                    <hr />
                </div>--%>
                <h3><asp:Label ID="lblNone" runat="server" Text="No Packages" Visible="false"></asp:Label></h3>
            </div>
            

        </div>
        
    </section>
</asp:Content>
