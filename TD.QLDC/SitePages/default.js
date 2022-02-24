Handlebars.registerHelper('handleText', function () {
    var maxLengthDisplay = 15;
    var title = this.text;
    if (title.length <= maxLengthDisplay) return title;

    var shortTitle = title.slice(0, maxLengthDisplay) + '...';
    return shortTitle;
});

$.ajax({
    url: '/qldcapi/dashboard/widget',
    method: 'GET',
    contentType: 'application/json'
}).done(function (data) {
    var source = document.getElementById('widget-template').innerHTML;
    var template = Handlebars.compile(source);
    var widgetElement = template(data.result);
    $('.widget-wrapper').append(widgetElement);
});



$.ajax({
    url: '/qldcapi/dashboard/chart1',
    method: 'GET',
    contentType: 'application/json'
}).done(function(data) {
    AmCharts.makeChart(document.querySelector('.chart1'), {
        "type": "serial",
        "theme": "none",
        "marginRight": 70,
        "dataProvider": data.result.data,
        "valueAxes": [{
            "axisAlpha": 0,
            "position": "left",
        }],
        "startDuration": 1,
        "graphs": [{
            "balloonText": "<b>[[category]]:<br/> số lượng hộ [[value]]</b>",
            "fillColorsField": "color",
            "fillAlphas": 0.9,
            "lineAlpha": 0.2,
            "type": "column",
            "valueField": "value"
        }, {
            "balloonText": "<b>[[category]]:<br/> số lượng hộ [[value2]]</b>",
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
})

$.ajax({
  url: '/qldcapi/dashboard/chart2',
  method: 'GET',
  contentType: 'application/json'
}).done(function(data) {
  AmCharts.makeChart(document.querySelector('.chart2'), {
      "type": "serial",
      "theme": "none",
      "marginRight": 70,
      "dataProvider": data.result.data,
      "valueAxes": [{
          "axisAlpha": 0,
          "position": "left",
      }],
      "startDuration": 1,
      "graphs": [{
          "balloonText": "<b>[[category]]:<br/> số lượng nhân khẩu [[value]]</b>",
          "fillColorsField": "color",
          "fillAlphas": 0.9,
          "lineAlpha": 0.2,
          "type": "column",
          "valueField": "value"
      }, {
          "balloonText": "<b>[[category]]:<br/> số lượng nhân khẩu [[value2]]</b>",
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
})
