/**
 *
 * @author 
 *
 */
class Word extends eui.Component {

	protected lb_text: eui.Label;
	public constructor() {
		super();

		this.lb_text.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_tap, this);
	}

	protected onclick_tap() {
		console.log("click word: " + this.lb_text.text);
		SceneGame.Shared().onclick_word(this);
	}

	// 未做成属性：当引用到eui的时候，Skin还未指定，运行时会报错。如果指定了SkinName，就会产生两次eui的构建 浪费内存
	public setWordText(value: string) {
		this.lb_text.text = value;
	}

	public getWordText(): string {
		return this.lb_text.text;
	}
}
