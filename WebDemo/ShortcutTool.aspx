<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortcutTool.aspx.cs" Inherits="WebDemo.ShortcutTool" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- 引入 Bootstrap -->
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 Shiv 和 Respond.js 用于让 IE8 支持 HTML5元素和媒体查询 -->
    <!-- 注意： 如果通过 file://  引入 Respond.js 文件，则该文件无法起效果 -->
    <!--[if lt IE 9]>
       <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
       <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <style>
        html, body, iframe {
            width: 100%;
            height: 100%;
            padding: 0;
            margin: 0;
        }

        #wrap {
            width: 100%;
            height: 100%;
        }

        iframe {
            border: none;
        }
    </style>
</head>
<body>
    <%--<div id="wrap">
        <iframe src="http://fanyi.youdao.com/" name="sendMessage"></iframe>
    </div>--%>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="container">
        <div class="row clearfix">
            <div class="col-md-12 column">
                <h2>
                    在线生成数据表
                </h2>
                <p style="color:red">
                   目前仅支持创建sql数据表
                </p>
                <div class="form-group">
                <label class="col-sm-2 control-label">表名前缀（示例：ISO）</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="inputStart" placeholder="输入以什么开头" runat="server">
                </div>
                </div>
                <div class="form-group">
                <label for="inputPassword" class="col-sm-2 control-label">表名（示例：车辆申请）</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="inputName" placeholder="输入表名名称" runat="server">
                </div>
                </div>
                <p>
                    <label class="radio-inline">
                       <input type="radio" name="inlineRadioOptions" id="flowCk"  runat="server">英文流程表
                    </label>
                    <label class="radio-inline">
                       <input type="radio" name="inlineRadioOptions" id="ConventionalCk" runat="server" checked>英文普通表
                   </label>
                    <label class="radio-inline">
                       <input type="radio" name="inlineRadioOptions" id="flowCkPY" runat="server">拼音首字母流程表
                    </label>
                    <label class="radio-inline">
                       <input type="radio" name="inlineRadioOptions" id="ConventionalCkPY"  runat="server">拼音首字母普通表
                   </label>
                    <label class="radio-inline">
                       <input type="radio" name="inlineRadioOptions" id="AutoCodeCk"  runat="server">自动编号首字母+编号模板
                   </label>

                </p>
                
            </div>
        </div>
        <div class="row clearfix">
            <div class="col-md-12 column">
                <textarea id="txtarea" class="form-control" rows="10" placeholder="请输入输入中文字段" runat="server"></textarea>
               <%-- <div id='MicrosoftTranslatorWidget' class='Dark' style='color:white;background-color:#555555'></div><script type='text/javascript'>setTimeout(function(){{var s=document.createElement('script');s.type='text/javascript';s.charset='UTF-8';s.src=((location && location.href && location.href.indexOf('https') == 0)?'https://ssl.microsofttranslator.com':'http://www.microsofttranslator.com')+'/ajax/v3/WidgetV3.ashx?siteData=ueOIGRSKkd965FeEGM5JtQ**&ctf=False&ui=true&settings=undefined&from=';var p=document.getElementsByTagName('head')[0]||document.documentElement;p.insertBefore(s,p.firstChild); }},0);</script>--%>
            </div>
            <p>
                 <a class="btn" href="Help.aspx" target="_blank">在线帮助</a>
                 
             </p>
        </div>
        <div class="row clearfix">
            <div class="col-md-12 column">
                <asp:Button ID="BtnSure" class="btn btn-default btn-block btn-success" runat="server" Text="在线生成" OnClick="BtnSure_Click" />
            </div>
        </div>
        <div class="row clearfix">
            <div class="col-md-12 column">
                <h2>
                    生成数据表在此展示
                </h2>
                <pre id="showText" runat="server">
                    







                </pre>
                <p>
                    <a class="btn" href="MoreInfomation.aspx" target="_blank">更多信息</a>
                </p>
            </div>
        </div>
        <div class="row clearfix">
            <div class="col-md-12 column">
            </div>
        </div>
    </div>
    </form>
    <script src="https://code.jquery.com/jquery.js"></script>
    <!-- 包括所有已编译的插件 -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
