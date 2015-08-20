<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SelfServices.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Self Service</title>
    <link rel="stylesheet" href="/Styles/bootstrap.min.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="/Scripts/scripts.js"></script>
</head>
<body>
    <div id="login-overlay" class="modal-dialog">
      <div class="modal-content">
          <div class="modal-header">             
              <h4 class="modal-title" id="myModalLabel">Welcome To Self Service</h4>
          </div>
          <div class="modal-body">
              <div class="row">
                  <div class="col-xs-2"></div>
                  <div class="col-xs-8">
                      <div class="well">
                          <form id="registerForm" runat="server" method="post" action="/Pages/Register.aspx">
                              <div class="form-group">
                                  <label for="customerId" class="control-label">Customer Id</label>
                                  <input type="text" class="form-control" id="customerId" name="customerId" value="" required="" title="Please enter you customer id" placeholder="customer id"/>                                  
                              </div>
                              <div class="form-group">
                                  <label for="username" class="control-label">Username</label>
                                  <input type="text" class="form-control" id="username" name="username" value="" required="" title="Please enter you username" placeholder="username"/>                                  
                              </div>
                              <div class="form-group">
                                  <label for="password" class="control-label">Password</label>
                                  <input type="password" class="form-control" id="password" name="password" value="" required="" title="Please enter your password" placeholder="password"/>                                  
                              </div>
                              <div class="form-group">
                                  <label for="secQuestion" class="control-label">Security Question</label>
                                  <select id="secQuestion" class="form-control" name="secQuestion">
                                        <option value="" disabled="disabled" selected="selected">- select -</option>
                                        <option>What is your pet's name?</option>
                                        <option>What is your nickname?</option>
                                  </select>
                              </div>
                              <div class="form-group">
                                  <label for="secAnswer" class="control-label">Security Answer</label>
                                  <input type="text" class="form-control" id="secAnswer" name="secAnswer" value="" required="" title="Please enter your security answer" placeholder="security answer"/>                                  
                              </div>
                              <div id="registerErrorMsg" class="alert alert-error"><%=ViewState["error"] %></div><br/><br/>

                              <input type="submit" value="Register" class="btn btn-success btn-block" />
                          </form>
                      </div>
                  </div>
                  <div class="col-xs-2"></div>
              </div>
          </div>
      </div>
  </div>
</body>

</html>
