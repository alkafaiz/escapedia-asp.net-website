<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="XML_ASSIGNMENT.contactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
            <section class="page-title page-title-4 bg-secondary">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                            <h3 class="uppercase mb0">Contact Us</h3>
                        </div>
                        <div class="col-md-6 text-right">
                            <ol class="breadcrumb breadcrumb-2">
                                <li>
                                    <a href="index.html">Home</a>
                                </li>
                                <li>
                                    <a href="#">Pages</a>
                                </li>
                                <li class="active">Contact</li>
                            </ol>
                        </div>
                    </div>
                    <!--end of row-->
                </div>
                <!--end of container-->
            </section>
            <section class="p0">
                <div class="map-holder pt160 pb160">
                    
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3984.104126247587!2d101.6898459511456!3d3.0668349977557026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zM8KwMDQnMDAuNiJOIDEwMcKwNDEnMzEuMyJF!5e0!3m2!1sen!2smy!4v1548272316593"></iframe>
                </div>
            </section>
            <section>
                <div class="container">
                    <div class="row">
                        <div class="col-sm-6 col-md-5">
                            <h4 class="uppercase">Get In Touch</h4>
                            <p>
                                At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident,
                            </p>
                            <hr>
                            <p>
                                No. 71, Jl. 124/27e Sri Petaling
                                <br /> Kuala Lumpur, Kuala Lumpur Federal Territory
                                <br /> P.O Box 57000
                            </p>
                            <hr>
                            <p>
                                <strong>E:</strong> hello@escapedia.com
                                <br />
                                <strong>P:</strong> +602 1923 6932
                                <br />
                            </p>
                        </div>
                        <div class="col-sm-6 col-md-5 col-md-offset-1">
                            <form class="form-email" data-success="Thanks for your submission, we will be in touch shortly." data-error="Please fill all fields correctly.">
                                <input type="text" class="validate-required" name="name" placeholder="Your Name" />
                                <input type="text" class="validate-required validate-email" name="email" placeholder="Email Address" />
                                <textarea class="validate-required" name="message" rows="4" placeholder="Message"></textarea>
                                <button type="submit">Send Message</button>
                            </form>
                        </div>
                    </div>
                    <!--end of row-->
                </div>
                <!--end of container-->
            </section>
            
        </div>
</asp:Content>
