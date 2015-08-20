<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SelfServices.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Self Service</title>
    <link rel="stylesheet" href="/Styles/bootstrap.min.css" />
    <link rel="stylesheet" href="/Styles/font-awesome.min.css" />
</head>
<body>
    <div id="login-overlay" class="modal-dialog">
      <div class="modal-content">
          <div class="modal-header">             
              <h4 class="modal-title" id="myModalLabel">Welcome To Self Service</h4>
          </div>
          <div class="modal-body">
              <div class="row">
                  <div class="col-xs-6">
                      <div class="well">
                          <form id="loginForm" method="post" action="/Pages/Login.aspx" novalidate="novalidate">
                              <div class="form-group">
                                  <label for="username" class="control-label">Username</label>
                                  <input type="text" class="form-control" id="username" name="username" value="" required="" title="Please enter you username" placeholder="username"/>                                  
                              </div>
                              <div class="form-group">
                                  <label for="password" class="control-label">Password</label>
                                  <input type="password" class="form-control" id="password" name="password" value="" required="" title="Please enter your password" placeholder="password"/>                                  
                              </div>
                              <a href="Pages/ForgotPassword.aspx" id="forgotPwd" class="text-info">Forgot Password?</a>
                              <div id="loginErrorMsg" class="alert alert-error hide">Invalid username/password</div><br/><br/>

                              <button type="submit" class="btn btn-success btn-block">Login</button>
                          </form>
                      </div>
                  </div>
                  <div class="col-xs-6">
                      <p class="lead" >Register Now</p>
                      <ul class="list-unstyled" style="line-height: 1.9">
                          <li><span class="fa fa-check text-success"></span> Check Order Status</li>
                          <li><span class="fa fa-check text-success"></span> Change Installation Date</li>
                          <li><span class="fa fa-check text-success"></span> Cancel Order</li>
                          <li><span class="fa fa-check text-success"></span> View and Pay Bill</li>
			  <li><span class="fa fa-check text-success"></span> Report Problems</li>
                      </ul>
		      <br/>
                      <p><a href="/Pages/Register.aspx" class="btn btn-info btn-block">Register now!</a></p>
                  </div>
              </div>
          </div>
      </div>
  </div>
</body>

</html>
