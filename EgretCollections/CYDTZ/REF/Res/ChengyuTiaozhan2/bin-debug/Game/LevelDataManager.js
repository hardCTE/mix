//每个问题（关卡）的数据结构
var LevelDataItem = (function () {
    function LevelDataItem() {
    }
    var d = __define,c=LevelDataItem,p=c.prototype;
    return LevelDataItem;
})();
egret.registerClass(LevelDataItem,'LevelDataItem');
//关卡数据管理器
var LevelDataManager = (function () {
    function LevelDataManager() {
        //一个关卡的保存数据组
        this.items = [];
        //使用RES读取和构建JSON数据，JSON数据可以直接解析到目标结构
        this.items = RES.getRes("questions_json");
    }
    var d = __define,c=LevelDataManager,p=c.prototype;
    LevelDataManager.Shared = function () {
        if (LevelDataManager.shared == null) {
            LevelDataManager.shared = new LevelDataManager();
        }
        return LevelDataManager.shared;
    };
    //通过关卡号获得一个关的数据
    p.GetLevel = function (level) {
        if (level < 0)
            level = 0;
        if (level >= this.items.length)
            level = this.items.length - 1;
        return this.items[level];
    };
    d(p, "Milestone"
        //获得当前的游戏最远进度
        ,function () {
            var milestone = egret.localStorage.getItem("CYDTZ_Milestone");
            //如果没有数据，那么默认值就是第一关
            if (milestone == "" || milestone == null) {
                milestone = "1";
            }
            return parseInt(milestone);
        }
        //设置当前的游戏最远进度
        ,function (value) {
            egret.localStorage.setItem("CYDTZ_Milestone", value.toString());
        }
    );
    return LevelDataManager;
})();
egret.registerClass(LevelDataManager,'LevelDataManager');
//# sourceMappingURL=LevelDataManager.js.map