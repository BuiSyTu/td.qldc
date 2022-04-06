<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/QLDC/default.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document"%>
<%@ Register TagPrefix="layout" Namespace="TD.Core.Layouts.Controls" Assembly="TD.Core.Layouts.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fdcb66d7090aabcd" %>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageHeaderTitle">
    DashBoard
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
	<div id="app">
        <div class="row widget-wrapper">
            <script id="widget-template" type="text/x-handlebars-template">
                {{#each data}}
                    <div class="col-3 mb-4">   
                        <div
                            class="small-box bg-info row"
                            style="background-color:{{this.backgroundColor}}!important;"
                            title="{{this.text}}"
                        >
                            <div class="inner col-8">
                                <h3>{{this.value}}</h3>
                        
                                <p>{{handleText}}</p>
                            </div>
                            <div class="col-4">
                                <i class="icon {{this.iconClass}}"></i>
                            </div>
                            <a href="{{this.link}}" class="small-box-footer col-12">Thông tin thêm <i class="fas fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                {{/each}}
            </script>
        </div>

        <div class="row">
            <!-- <div class="col-xl-4">                       
                <div class="m-portlet m-portlet--full-height ">
                    
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <i class="flaticon-bell RingABell&nbsp;&nbsp;"></i>        
                                <h3 class="m-portlet__head-text">
                                    Nhắc việc
                                </h3>
                            </div>
                        </div>					
                    </div>
            
                    
                    <div class="m-portlet__body">
                    
                    
                        <div class="m-widget1">         
                                
                            <div class="m-widget1__item">
                                <div class="row m-row--no-padding align-items-center">
                                    <div class="col-9">
                                        <h3 class="m-widget1__title">
                                            Đề xuất chi trả chờ duyệt
                                        </h3>
                                    </div>
                                    <div class="col-3 m--align-right">
                                        <span class="m-widget1__number m--font-danger">
                                            1
                                        </span>
                                    </div>
                                </div>
                            </div>
            
                        </div>
                        
                        <div class="m-widget1">
                            <div class="m-widget1__item">
                                <div class="row m-row--no-padding align-items-center">
                                    <div class="col-9">
                                        <h3 class="m-widget1__title">
                                            Chứng nhận đối tượng bảo trợ chờ duyệt
                                        </h3>
                                    </div>
                                    <div class="col-3 m--align-right">
                                        <span class="m-widget1__number m--font-danger">
                                            2
                                        </span>
                                    </div>
                                </div>
                            </div>
            
                        </div>
                    </div>
                </div>
            </div> -->

            <div class="col-6">
                <div class="m-portlet m-portlet--full-height">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">    
                                <h3 class="m-portlet__head-text">
                                    Số hộ theo xóm
                                </h3>
                            </div>
                        </div>					
                    </div>
                    <div class="m-portlet__body">
                        <div class='chart1'
                            style="width:640px;height:400px;">
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div class="m-portlet m-portlet--full-height ">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">    
                                <h3 class="m-portlet__head-text">
                                    Số nhân khẩu theo xóm
                                </h3>
                            </div>
                        </div>					
                    </div>
                    <div class="m-portlet__body">
                        <div class='chart2'
                            style="width:100%;height:400px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <!-- <div class="col-6">
                <div class="m-portlet m-portlet--full-height ">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">    
                                <h3 class="m-portlet__head-text">
                                    Các loại đề xuất chi trả
                                </h3>
                            </div>
                        </div>					
                    </div>
                    <div class="m-portlet__body">
                        <div class='chart2'
                            style="width:640px;height:400px;">
                        </div>
                    </div>
                </div>    
            </div> -->
        </div>
 

    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageVendorStyles">
	<link type="text/css" rel="stylesheet" href="/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.css" />
    <link rel="stylesheet" href="default.css">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageVendorScripts">
    <script type="text/javascript" src="/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.js"></script>
     
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageScripts">
    <script src="js/amcharts/amchart.js"></script>
	<script src="js/amcharts/pie.js"></script>
	<script src="js/amcharts/serial.js"></script>
    <script src="default.js"></script>
</asp:Content>