<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="XML_ASSIGNMENT.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
            <section class="cover fullscreen image-bg overlay">
                <div class="background-image-holder">
                    <img alt="image" class="background-image" src="img/home12.jpg" />
                </div>
                <div class="container v-align-transform">
                    <div class="row">
                        <div class="col-md-4 col-md-offset-4 col-sm-8 col-sm-offset-2">
                            <div class="feature bordered text-center">
                                <h4 class="uppercase">Login Here</h4>
                                <form runat="server" class="text-left">
                                    
                                    <asp:TextBox ID="txtUname" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                    
                                    <asp:TextBox ID="txtPw" TextMode="Password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                    
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                    <asp:PlaceHolder ID="alert1" runat="server"></asp:PlaceHolder>
                                </form>
                                <p class="mb0">Forgot your password?
                                    <a href="#">Click Here To Reset</a>
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
