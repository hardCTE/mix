// 问题数据结构
var LevelDataItem = (function () {
    function LevelDataItem() {
    }
    var d = __define,c=LevelDataItem,p=c.prototype;
    return LevelDataItem;
}());
egret.registerClass(LevelDataItem,'LevelDataItem');
var LevelDataManager = (function () {
    function LevelDataManager() {
        console.log("data manager: start" + new Date().getTime);
        this.items = RES.getRes("questions_json");
        console.log("data manager: end" + new Date().getTime);
    }
    var d = __define,c=LevelDataManager,p=c.prototype;
    LevelDataManager.Shared = function () {
        if (LevelDataManager.shared == null) {
            LevelDataManager.shared = new LevelDataManager();
        }
        return LevelDataManager.shared;
    };
    // 根据关号 获取数据
    p.GetLeve = function (level) {
        if (level < 0)
            level = 0;
        if (level >= this.items.length) {
            level = this.items.length - 1;
        }
        return this.items[level];
    };
    d(p, "Milestone"
        // 获取存档
        ,function () {
            var ms = egret.localStorage.getItem("CYDTZ_Milestone");
            if (ms == null || ms == "") {
                ms = "1";
            }
            return parseInt(ms);
        }
        // 设置存档
        ,function (value) {
            egret.localStorage.setItem("CYDTZ_Milestone", value.toString());
        }
    );
    return LevelDataManager;
}());
egret.registerClass(LevelDataManager,'LevelDataManager');
//# sourceMappingURL=LevelDataManager.js.map