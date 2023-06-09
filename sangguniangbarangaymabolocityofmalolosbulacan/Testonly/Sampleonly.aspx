﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Testonly/Testonly.Master" AutoEventWireup="true" CodeBehind="Sampleonly.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.Testonly.Sampleonly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">Barangay Mabolo</a>
            </div>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li class="active"><a href="index.html"><i class="fa fa-bullseye"></i> Dashboard</a></li>
                    <li><a href="portfolio.html"><i class="fa fa-tasks"></i> Barangay Clearance</a></li>
                    <li><a href="blog.html"><i class="fa fa-globe"></i> Blog</a></li>
                    <li><a href="signup.html"><i class="fa fa-list-ol"></i> SignUp</a></li>
                    <li><a href="register.html"><i class="fa fa-font"></i> Register</a></li>
                    <li><a href="timeline.html"><i class="fa fa-font"></i> Timeline</a></li>
                    <li><a href="forms.html"><i class="fa fa-list-ol"></i> Forms</a></li>
                    <li><a href="typography.html"><i class="fa fa-font"></i> Typography</a></li>
                    <li><a href="bootstrap-elements.html"><i class="fa fa-list-ul"></i> Bootstrap Elements</a></li>
                    <li><a href="bootstrap-grid.html"><i class="fa fa-table"></i> Bootstrap Grid</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right navbar-user">
                    
                     <li class="dropdown user-dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> Steve Miller<b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="#"><i class="fa fa-user"></i> Profile</a></li>
                            <li><a href="#"><i class="fa fa-gear"></i> Settings</a></li>
                            <li class="divider"></li>
                            <li><a href="#"><i class="fa fa-power-off"></i> Log Out</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
        <div>
        <div class="row text-center">
            <h2>New Registration</h2>
        </div>
        <div>
            <label for="firstname" class="col-md-2">
                First Name:
            </label>
            <div class="col-md-9">
                <input type="text" class="form-control" id="firstname" placeholder="Enter First Name">
            </div>
            <div class="col-md-1">
                <i class="fa fa-lock fa-2x"></i>
            </div>
        </div>        
        <div>
            <label for="lastname" class="col-md-2">
                Last Name:
            </label>
            <div class="col-md-9">
                <input type="text" class="form-control" id="lastname" placeholder="Enter Last Name">
            </div>
             <div class="col-md-1">
                <i class="fa fa-lock fa-2x"></i>
            </div>
        </div>
        <div>
            <label for="emailaddress" class="col-md-2">
                Email address:
            </label>
            <div class="col-md-9">
                <input type="email" class="form-control" id="emailaddress" placeholder="Enter email address">
                <p class="help-block">
                    Example: yourname@domain.com
                </p>
            </div>
             <div class="col-md-1">
                <i class="fa fa-lock fa-2x"></i>
            </div>
        </div>
        <div>
            <label for="password" class="col-md-2">
                Password:
            </label>
            <div class="col-md-9">
                <input type="password" class="form-control" id="password" placeholder="Enter Password">
                <p class="help-block">
                    Min: 6 characters (Alphanumeric only)
                </p>
            </div>
             <div class="col-md-1">
                <i class="fa fa-lock fa-2x"></i>
            </div>
        </div>
        <div>
            <label for="sex" class="col-md-2">
                Gender:
            </label>
            <div class="col-md-10">
                <label class="radio">
                    <input type="radio" name="sex" id="sex" value="male" checked>
                    Male
                </label>
                <label class="radio">
                    <input type="radio" name="sex" id="Radio1" value="female">
                    Female
                </label>
            </div>             
        </div>
        <div>
            <label for="country" class="col-md-2">
                Country:
            </label>
            <div class="col-md-9">
                <select name="country" id="country" class="form-control">
                    <option>--Please Select--</option>
                    <option>India</option>
                    <option>United States</option>
                    <option>Canada</option>
                    <option>United Kingdom</option>
                    <option>Others</option>
                </select>
            </div>            
        </div>
        <div>
            <label for="uploadimage" class="col-md-2">
                Upload Image:
            </label>
            <div class="col-md-10">
                <input type="file" name="uploadimage" id="uploadimage">
                <p class="help-block">
                    Allowed formats: jpeg, jpg, gif, png
                </p>
            </div>          
        </div>
        <div>
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                <label>
                    <input type="checkbox">I hereby accept the terms and conditions for using this site</label>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                <button type="submit" class="btn btn-info">
                    Register
                </button>
            </div>
        </div>
    </div>  
       
    </div>



     
</asp:Content>
