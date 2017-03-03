// 继承自 问题字，答案字 是放在上面回答区域。由于当答案字点击的时候，答案字会消失并将对应的问题自还原显示
var AnswerWord = (function (_super) {
    __extends(AnswerWord, _super);
    function AnswerWord() {
        _super.call(this);
        this.SelectWord = null;
    }
    var d = __define,c=AnswerWord,p=c.prototype;
    p.onclick_tap = function () {
        if (this.SelectWord != null) {
            this.SelectWord.visible = true;
            this.SelectWord = null;
            this.setWordText("");
        }
        console.log("click answer word ..");
    };
    // 当一个问题字被选择添加到回答时，设置不可见，并保存到本对象中以后使用
    p.SetSelectWord = function (word) {
        if (word == null) {
            this.setWordText("");
        }
        else {
            word.visible = false;
            this.setWordText(word.getWordText());
        }
        this.SelectWord = word;
    };
    return AnswerWord;
}(Word));
egret.registerClass(AnswerWord,'AnswerWord');
//# sourceMappingURL=AnswerWord.js.map