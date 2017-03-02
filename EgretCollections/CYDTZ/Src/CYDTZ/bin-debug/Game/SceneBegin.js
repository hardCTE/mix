/**
 *
 * @author
 *
 */
var SceneBegin = (function (_super) {
    __extends(SceneBegin, _super);
    function SceneBegin() {
        _super.call(this);
        this.skinName = "src/Game/SceneBeginSkin.exml";
        this.btn_begin.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_begin, this);
    }
    var d = __define,c=SceneBegin,p=c.prototype;
    p.onclick_begin = function () {
        console.log("touch begin...... game begin!");
    };
    return SceneBegin;
}(eui.Component));
egret.registerClass(SceneBegin,'SceneBegin');
//# sourceMappingURL=SceneBegin.js.map