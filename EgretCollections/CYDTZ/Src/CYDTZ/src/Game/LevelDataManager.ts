// 问题数据结构
class LevelDataItem {
    public anser:string;
    public img:string;
    public word:string;
    public tip:string;
    public content:string;
}

class LevelDataManager {
    private static shared:LevelDataManager;
    public static Shared(){
        if(LevelDataManager.shared == null) {
            LevelDataManager.shared = new LevelDataManager();
        }

        return LevelDataManager.shared;
    }

    private items:LevelDataItem[];

    public constructor() {
        this.items = RES.getRes("questions_json");
    }

    // 根据关号 获取数据
    public GetLeve(level:number):LevelDataItem {
        if(level < 0) level = 0;
        if(level >= this.items.length){
            level = this.items.length -1;
        }

        return this.items[level];
    }

    // 获取存档
    public get Milestone():number {
        var ms =egret.localStorage.getItem("CYDTZ_Milestone");

        if(ms == null || ms == "") {
            ms = "1";
        }

        return parseInt(ms);
    }

    // 设置存档
    public set Milestone(value:number){
        egret.localStorage.setItem("CYDTZ_Milestone",value.toString());
    }

}