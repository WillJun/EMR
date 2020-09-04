// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var api_domain = 'http://ap-flow.emersonnanjing.com:8006/api'
//var api_domain = 'https://localhost:44313'

//写Cookie
function addCookie(objName, objValue, objHours)
{
    var str = objName + "=" + escape(objValue); //编码
    if (objHours > 0)
    {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

//读Cookie
function getCookie(objName)
{//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++)
    {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);  //解码
    }
    return "";
}

//// 添加请求拦截器
//axios.interceptors.request.use(function (config)
//{
//    // 在发送请求之前做些什么
//    config =>
//    {
//        if (config.method == 'post')
//        {
//            config.data = {
//                ...config.data,
//                _t: Date.parse(new Date()) / 1000
//            }
//        } else if (config.method == 'get')
//        {
//            config.params = {
//                _t: Date.parse(new Date()) / 1000,
//                ...config.params
//            }
//        }

//        return config
//    }, function (error)
//        {
//            // 对请求错误做些什么
//            return Promise.reject(error)
//        }
//});