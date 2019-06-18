<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="XML_ASSIGNMENT.feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UserName" runat="server">
    <a href="#">Feedback</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="uppercase">Submit Feedback</h3>
                    <hr>
                </div>
            </div>
            <div class="row">
                <form class="form-email" data-success="Thanks for your submission, we will be in touch shortly." data-error="Please fill all fields correctly.">
                    <input type="text" class="validate-required" name="name" placeholder="Your Name" />
                    <input type="text" class="validate-required validate-email" name="email" placeholder="Email Address" />
                    <textarea class="validate-required" name="message" rows="4" placeholder="Message"></textarea>
                    <button type="submit">Send Message</button>
                </form>
            </div>
            
        </div>
    </section>
</asp:Content>
