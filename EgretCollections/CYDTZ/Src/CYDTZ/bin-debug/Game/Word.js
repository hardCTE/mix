/**
 *
 * @author
 *
 */
var Word = (function (_super) {
    __extends(Word, _super);
    function Word() {
        _super.call(this);
        this.lb_text.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_tap, this);
    }
    var d = __define,c=Word,p=c.prototype;
    p.onclick_tap = function () {
        console.log("click word: " + this.lb_text.text);
        SceneGame.Shared().onclick_word(this);
    };
    // 未做成属性：当引用到eui的时候，Skin还未指定，运行时会报错。如果指定了SkinName，就会产生两次eui的构建 浪费内存
    p.setWordText = function (value) {
        this.lb_text.text = value;
    };
    p.getWordText = function () {
        return this.lb_text.text;
    };
    return Word;
}(eui.Component));
egret.registerClass(Word,'Word');
//# sourceMappingURL=Word.js.map