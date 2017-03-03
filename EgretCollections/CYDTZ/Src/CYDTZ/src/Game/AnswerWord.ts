// 继承自 问题字，答案字 是放在上面回答区域。由于当答案字点击的时候，答案字会消失并将对应的问题自还原显示
class AnswerWord extends Word {

	public SelectWord: Word = null;

	public constructor() {
		super();
	}

	protected onclick_tap() {
		if (this.SelectWord != null) {
			this.SelectWord.visible = true;
			this.SelectWord = null;
			this.setWordText("");
		}

		console.log("click answer word ..");
	}

	// 当一个问题字被选择添加到回答时，设置不可见，并保存到本对象中以后使用
	public SetSelectWord(word: Word) {
		if (word == null) {
			this.setWordText("");
		} else {
			word.visible = false;
			this.setWordText(word.getWordText());
		}

		this.SelectWord = word;
	}
}