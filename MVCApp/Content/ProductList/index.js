//按钮事件
var btnAct = {};
var search = {};
var SearchUser = {};

//弹框
var winObj = null;
var openType = '';
var chooseData = {};
var layer, table;
var reload;
layui.use(function () {
    table = layui.table;
    layer = layui.layer;
    //显示数据
    table.render({
        elem: '#demo',
        cols: [
            [{
                field: 'ID',//数据库字段
                title: 'ID',//列表标题
                width: 100,
                sort: true
            }, {
                field: 'ProductName',
                title: 'Product Name',
                width: 120,
            }, {
                field: 'ProductManu',
                title: 'Product Manufactor',
                width: 200,
            }, {
                field: 'ProductPrice',
                title: 'Price',
                width: 100,
                sort: true
            }, {
                field: 'ProductYear',
                title: 'Year',
                width: 100,
                sort: true
            }, {
                field: "",
                title: "",
                minwidth: 400,
                templet: '#btn'
            }]
        ],
        data: [],
        even: true,
        page: true,
        limit: 10 //页默认显示数

    });

    function open() {
        winObj = layer.open({
            type: 2,
            area: ['800px', '450px'],
            fixed: false,
            maxmin: true,
            content: 'http://localhost:57956/Home/ProductDetail'
        });
    }
    //search method
    search = function () {
        var searchCondition = $('#searchCondition').val();
        $.ajax({
            url: "/Home/GetProductList",
            data: {
                keyWord: searchConditon
            },
            success: function (res) {
                var data = JSON.parse(res);
                table.reload('demo', { data: data }, true)
            }
        });
    }
    //search user method
    SearchUser = function () {
        winObj = layer.open({
            type: 2,
            area: ['1000px', '500px'],
            fixed: false,
            maxmin: true,
            content: 'http://loaclhost:57956/Home/UserList'
        });
    }

    reload = function () {
        $.ajax({
            url: "/Home/GetProductList",
            data: { keyWord: "" },
            success: function (res) {
                var data = JSON.parse(res);
                console.log(data);
                table.reload('demo', { data: data }, true)
            }
        });
    }

    btnAct = function (type, id) {
        openType = type;
        if (type == 'del') {
            layer.confirm('Confirm delete no reverse', function (index) {
                $.ajax({
                    url: "/Home/DeleteProduct",
                    data: { ID: id },
                    success: function (res) {
                        reload();
                        layer.close(index);
                    }
                });
            });
            return;
        }
        if (type = "SearchUser") {
            winObj = layer.open({
                type: 2,
                area: ['800px', '450px'],
                fixed: false,
                maxmin: true,
                content: 'http://localhost:57956/Home/UserList'
            });
        }
        if (id) {
            //调用查询单个数据 edit时用
            $.ajax({
                url: "/Home/GetSingleProduct",
                data: { ID: id },
                success: function (res) {
                    var data = JSON.parse(res);
                    chooseData = data;
                }
            });
        }
        else {
            chooseData = {};
        }
        open();
    }
    reload();
});