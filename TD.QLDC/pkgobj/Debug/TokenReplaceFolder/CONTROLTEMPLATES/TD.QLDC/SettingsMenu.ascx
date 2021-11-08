<%@ Assembly Name="TD.QLDC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=c78f98c001a3d004" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsMenu.ascx.cs" Inherits="TD.QLDC.ControlTemplates.TD.QLDC.SettingsMenu" %>
<%@ Register Tagprefix="layout" Namespace="TD.Core.Layouts.Controls" Assembly="TD.Core.Layouts.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fdcb66d7090aabcd" %>
<ul class="m-nav m-nav--skin-light">
	<li class="m-nav__item">
        <layout:HyperLink runat="server" NavigateUrl="~coreroot/sites/admin/SitePages/users.aspx" target="_blank" class="m-nav__link">
            <i class="m-nav__link-icon la la-users"></i>
			<span class="m-nav__link-text">
				Người dùng
			</span>
        </layout:HyperLink>
	</li>
	<li class="m-nav__item">
        <layout:HyperLink runat="server" NavigateUrl="~coreroot/sites/admin/SitePages/group.aspx" target="_blank" class="m-nav__link">
            <i class="m-nav__link-icon la la-sitemap"></i>
			<span class="m-nav__link-text">
				Cơ cấu tổ chức
			</span>
        </layout:HyperLink>
	</li>
</ul>
