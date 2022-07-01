layui.use(function() {
    var form = layui.form,
        layer = layui.layer,
        layedit = layui.layedit,
        laydate = layui.laydate;
    laydate.render({

    });

    form.val("addForm", parent.chooseData);

    form.on('submit(sub)', function (data) {
        var type = parent.openType;
        var data = data.field;
        if (type === 'add') {
            $.ajax({
                url: "/Home/InsertProduct",
                data: data,
                success: function (res) {
                    parent.reload();
                    parent.layer.close(parent.winObj);
                }
            });
        } else if (type == 'edit') {
            data.ID = parent.chooseData.ID;
            $.ajax({
                url: "/Home/",
            })
        }
    }
}