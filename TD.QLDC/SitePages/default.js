Handlebars.registerHelper('handleText', function () {
    var maxLengthDisplay = 15;
    var title = this.text;
    if (title.length <= maxLengthDisplay) return title;

    var shortTitle = title.slice(0, maxLengthDisplay) + '...';
    return shortTitle;
});

var dataWidget = {
    "status": 200,
    "message": null,
    "result": {
      "title": "Thống kê danh mục hệ thống",
      "data": [
        {
          "text": "Cơ sở bảo trợ",
          "value": 4,
          "iconClass": "flaticon-imac",
          "backgroundColor": "#007bff",
          "link": "/sites/btxh/Sitepages/DanhMuc/co-so-bao-tro.aspx",
          "textColor": "white"
        },
        {
          "text": "Việc làm",
          "value": 2,
          "iconClass": "flaticon-warning-2",
          "backgroundColor": "#28a745",
          "link": "/sites/btxh/Sitepages/DanhMuc/viec-lam.aspx",
          "textColor": "white"
        },
        {
          "text": "Đối tượng chính sách",
          "value": 2,
          "iconClass": "flaticon-twitter-logo",
          "backgroundColor": "#ffc107",
          "link": "/sites/btxh/Sitepages/DanhMuc/loai-doi-tuong-chinh-sach.aspx",
          "textColor": "white"
        },
        {
          "text": "Đối tượng bảo trợ",
          "value": 56,
          "iconClass": "flaticon-gift",
          "backgroundColor": "#dc3545",
          "link": "/sites/btxh/Sitepages/DanhMuc/loai-doi-tuong-bao-tro.aspx",
          "textColor": "white"
        }
      ]
    }
  }

// Widget
// $.ajax({
//     url: '/btxhapi/dashboard/widget',
//     method: 'GET',
//     contentType: 'application/json'
// }).done(function (data) {
//     var source = document.getElementById('widget-template').innerHTML;
//     var template = Handlebars.compile(source);
//     var widgetElement = template(data.result);
//     $('.widget-wrapper').append(widgetElement);
// });
var source = document.getElementById('widget-template').innerHTML;
var template = Handlebars.compile(source);
var widgetElement = template(dataWidget.result);
$('.widget-wrapper').append(widgetElement);


// Chart 1
// $.ajax({
//     url: '/btxhapi/dashboard/chart1a',
//     method: 'GET',
//     contentType: 'application/json'
// }).done(function(data) {
//     AmCharts.makeChart(document.querySelector('.chart1'), {
//         "type": "serial",
//         "theme": "none",
//         "marginRight": 70,
//         "dataProvider": data.result,
//         "valueAxes": [{
//             "axisAlpha": 0,
//             "position": "left",
//         }],
//         "startDuration": 1,
//         "graphs": [{
//             "balloonText": "<b>[[category]]:<br/> số lượng đối tượng bảo trợ [[value]]</b>",
//             "fillColorsField": "color",
//             "fillAlphas": 0.9,
//             "lineAlpha": 0.2,
//             "type": "column",
//             "valueField": "value"
//         }, {
//             "balloonText": "<b>[[category]]:<br/> số lượng đối tượng bảo trợ [[value2]]</b>",
//             "fillColorsField": "color",
//             "fillAlphas": 0.9,
//             "lineAlpha": 0.2,
//             "type": "column",
//             "valueField": "value2"
//         }],
//         "chartCursor": {
//             "categoryBalloonEnabled": false,
//             "cursorAlpha": 0,
//             "zoomable": false
//         },
//         "categoryField": "text",
//         "categoryAxis": {
//             "gridPosition": "start",
//             "labelRotation": 45
//         },
//         "export": {
//             "enabled": true
//         }
//     });
// })
var dataChart1 = {
    "status": 200,
    "message": null,
    "result": [
      {
        "text": "Phường Bắc Cường",
        "value": "108",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Bắc Lệnh",
        "value": "75",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Bình Minh",
        "value": "119",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Cốc Lếu",
        "value": "227",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Duyên Hải",
        "value": "56",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Kim Tân",
        "value": "197",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Lào Cai",
        "value": "194",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Pom Hán",
        "value": "172",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Thống Nhất",
        "value": "282",
        "value2": null,
        "color": null
      },
      {
        "text": "Phường Xuân Tăng",
        "value": "149",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Bản Mế",
        "value": "36",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Cán Cấu",
        "value": "29",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Cốc San",
        "value": "132",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Đồng Tuyển",
        "value": "55",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Hợp Thành",
        "value": "90",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Nàn Sán",
        "value": "60",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Sán Chải",
        "value": "24",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Sín Chéng",
        "value": "36",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Tả Phời",
        "value": "99",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Thào Chư Phìn",
        "value": "23",
        "value2": null,
        "color": null
      },
      {
        "text": "Xã Vạn Hòa",
        "value": "140",
        "value2": null,
        "color": null
      }
    ]
  }

  AmCharts.makeChart(document.querySelector('.chart1'), {
    "type": "serial",
    "theme": "none",
    "marginRight": 70,
    "dataProvider": dataChart1.result,
    "valueAxes": [{
        "axisAlpha": 0,
        "position": "left",
    }],
    "startDuration": 1,
    "graphs": [{
        "balloonText": "<b>[[category]]:<br/> số lượng đối tượng bảo trợ [[value]]</b>",
        "fillColorsField": "color",
        "fillAlphas": 0.9,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "value"
    }, {
        "balloonText": "<b>[[category]]:<br/> số lượng đối tượng bảo trợ [[value2]]</b>",
        "fillColorsField": "color",
        "fillAlphas": 0.9,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "value2"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "text",
    "categoryAxis": {
        "gridPosition": "start",
        "labelRotation": 45
    },
    "export": {
        "enabled": true
    }
});

// Chart 2
// $.ajax({
//     url: '/btxhapi/dashboard/chart2',
//     method: 'GET',
//     contentType: 'application/json',
//     async: false,
// }).done(function (data) {
//     AmCharts.makeChart(document.querySelector('.chart2'), {
//         "type": "pie",
//         "dataProvider": data.result.data,
//         "categoryField": "text",
//         "valueField": "value",
//         "titleField": "text",
//         "balloon": {
//             "fixedPosition": true
//         },
//         "export": {
//             "enabled": true
//         },
//     });
// });
var dataChart2 = {
    "status": 200,
    "message": null,
    "result": {
      "title": "Các loại chi trả",
      "data": [
        {
          "text": "Trợ cấp đột suất",
          "value": "200000",
          "value2": null,
          "color": null
        },
        {
          "text": "Trợ cấp hàng tháng",
          "value": "2469123",
          "value2": null,
          "color": null
        },
        {
          "text": "Hỗ trợ khẩn cấp",
          "value": "0",
          "value2": null,
          "color": null
        },
        {
          "text": "Hỗ trợ lương thực",
          "value": "0",
          "value2": null,
          "color": null
        },
        {
          "text": "Hỗ trợ mai táng phí",
          "value": "0",
          "value2": null,
          "color": null
        },
        {
          "text": "Trợ cấp làm - sửa chữa nhà cửa",
          "value": "0",
          "value2": null,
          "color": null
        }
      ]
    }
  }

  AmCharts.makeChart(document.querySelector('.chart3'), {
    "type": "pie",
    "dataProvider": dataChart2.result.data,
    "categoryField": "text",
    "valueField": "value",
    "titleField": "text",
    "balloon": {
        "fixedPosition": true
    },
    "export": {
        "enabled": true
    },
});

// Chart 3
// $.ajax({
//     url: '/btxhapi/dashboard/chart3',
//     method: 'GET',
//     contentType: 'application/json',
//     async: false,
// }).done(function (data) {
//     AmCharts.makeChart(document.querySelector('.chart3'), {
//         "type": "pie",
//         "dataProvider": data.result.data,
//         "categoryField": "text",
//         "valueField": "value",
//         "titleField": "text",
//         "balloon": {
//             "fixedPosition": true
//         },
//         "export": {
//             "enabled": true
//         },
//     });
// });