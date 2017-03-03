var SceneGame = (function (_super) {
    __extends(SceneGame, _super);
    function SceneGame() {
        _super.call(this);
        this.skinName = "src/Game/SceneGameSkin.exml";
        this.btn_back.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_back, this);
    }
    var d = __define,c=SceneGame,p=c.prototype;
    SceneGame.Shared = function () {
        if (SceneGame.shared == null) {
            SceneGame.shared = new SceneGame();
        }
        return SceneGame.shared;
    };
    p.InitLevel = function (level) {
        this.levelIndex = level;
        var levelData = LevelDataManager.Shared().GetLeve(level);
        // 拼接答案和备用字
        var words = levelData.answer + levelData.word;
        // 随机取另一个题目中的文段
        while (words.length < 20) {
            var tmp = Math.floor(Math.random() * 400); // 400道题
            if (tmp != level) {
                var tmpItem = LevelDataManager.Shared().GetLeve(tmp);
                words += tmpItem.answer + tmpItem.word;
            }
        }
        // 重排
        var wordsArr = [];
        for (var i = 0; i < words.length; i++) {
            wordsArr.push(words.charAt(i));
        }
        wordsArr = this.randomArr(wordsArr);
        //赋值
        for (var i = 0; i < this.group_words.numChildren; i++) {
            var wordrect = this.group_words.getChildAt(i);
            wordrect.setWordText(wordsArr[i]);
            wordrect.visible = true;
        }
        // 状态
        for (var i = 0; i < this.group_answer.numChildren; i++) {
            var answerrect = this.group_answer.getChildAt(i);
            answerrect.SetSelectWord(null);
            answerrect.visible = true;
            answerrect.SelectWord = null;
        }
        // 问题图片
        this.img_question.source = "resource/assets/" + levelData.img;
    };
    // 将数组随机重排
    p.randomArr = function (arr) {
        var rArr = [];
        while (arr.length > 0) {
            var tmp = Math.floor(Math.random() * arr.length);
            rArr.push(arr[tmp]);
            arr.slice(tmp, 1);
        }
        return rArr;
    };
    p.onclick_back = function () {
        console.log("back...");
        this.parent.addChild(SceneLevels.Shared());
        this.parent.removeChild(this);
    };
    // 点击字的时候，由word类调用
    p.onclick_word = function (word) {
        // 找到第一个合适的位置添加答案
        var sel = null;
        for (var i = 0; i < this.group_answer.numChildren; i++) {
            var curAnswer = this.group_answer.getChildAt(i);
            if (curAnswer.SelectWord == null) {
                sel = curAnswer;
                break;
            }
        }
        if (sel != null) {
            sel.SetSelectWord(word);
            //判断是否胜利
            var check_str = "";
            for (var i = 0; i < this.group_answer.numChildren; i++) {
                var curAnswer = this.group_answer.getChildAt(i);
                check_str += curAnswer.getWordText();
            }
            if (check_str == LevelDataManager.Shared().GetLeve(this.levelIndex).answer) {
                //胜利
                console.log("win ...");
            }
        }
    };
    return SceneGame;
}(eui.Component));
egret.registerClass(SceneGame,'SceneGame');
//# sourceMappingURL=SceneGame.js.map