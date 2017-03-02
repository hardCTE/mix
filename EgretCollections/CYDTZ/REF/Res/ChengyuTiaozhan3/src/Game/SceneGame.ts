


class SceneGame extends eui.Component {
    //单例
    private static shared: SceneGame;
    public static Shared() {
        if(SceneGame.shared == null) {
            SceneGame.shared = new SceneGame();
        }
        return SceneGame.shared;
    }
    public constructor() {
        super();
        this.skinName = "src/Game/SceneGameSkin.exml";
    }
    
}
