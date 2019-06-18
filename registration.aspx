<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="XML_ASSIGNMENT.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container ">
            <section class="cover fullscreen image-bg overlay">
                <div class="background-image-holder">
                    <img alt="image" class="background-image" src="img/home2.jpg" />
                </div>
                <div class="container v-align-transform">
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3">
                            <div class="feature bordered text-center">
                                <h4 class="uppercase">Register as partner</h4>
                                <form class="text-left" runat="server">                                    
                                    <asp:TextBox ID="txtUname" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                    <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                    <asp:TextBox ID="txtPw" TextMode="Password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                    <asp:TextBox ID="txtConfirmPw" TextMode="Password" runat="server" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox> 
                                    <!--<input type="submit" value="Register" />-->
                                    <asp:Button ID="btnRegist" runat="server" Text="Register" OnClick="btnRegist_Click" />
                                    <asp:PlaceHolder ID="alert1" runat="server"></asp:PlaceHolder>
                                </form>
                                <p class="mb0">By signing up, you agree to our
                                    <a href="#">Terms Of Use</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <!--end of row-->
                </div>
                <!--end of container-->
            </section>
            
        </div>
</asp:Content>
