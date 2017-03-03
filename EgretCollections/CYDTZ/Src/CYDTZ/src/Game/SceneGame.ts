class SceneGame extends eui.Component {
	private static shared: SceneGame;

	public static Shared() {
		if (SceneGame.shared == null) {
			SceneGame.shared = new SceneGame();
		}

		return SceneGame.shared;
	}

	private btn_back: eui.Button;
	private group_answer: eui.Group;
	private group_words: eui.Group;
	private img_question: eui.Image;
	private levelIndex: number;

	public constructor() {
		super();

		this.skinName = "src/Game/SceneGameSkin.exml";
		this.btn_back.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_back, this);
	}

	public InitLevel(level: number) {
		this.levelIndex = level;
		var levelData = LevelDataManager.Shared().GetLeve(level);

		// 拼接答案和备用字
		var words = levelData.answer + levelData.word;

		// 随机取另一个题目中的文段
		while (words.length < 20) {
			var tmp = Math.floor(Math.random() * 400);	// 400道题
			if (tmp != level) {
				var tmpItem = LevelDataManager.Shared().GetLeve(tmp)
				words += tmpItem.answer + tmpItem.word;
			}
		}

		// 重排
		var wordsArr: string[] = [];
		for (var i = 0; i < words.length; i++) {
			wordsArr.push(words.charAt(i));
		}

		wordsArr = this.randomArr(wordsArr);

		//赋值
		for (var i = 0; i < this.group_words.numChildren; i++) {
			var wordrect = <Word>this.group_words.getChildAt(i);
			wordrect.setWordText(wordsArr[i]);
			wordrect.visible = true;
		}

		// 状态
		for (var i = 0; i < this.group_answer.numChildren; i++) {
			var answerrect = <AnswerWord>this.group_answer.getChildAt(i);
			answerrect.SetSelectWord(null)
			answerrect.visible = true;
			answerrect.SelectWord = null;
		}

		// 问题图片
		this.img_question.source = "resource/assets/" + levelData.img;
	}

	// 将数组随机重排
	public randomArr(arr: any[]): any[] {
		var rArr: any[] = [];
		while (arr.length > 0) {
			var tmp = Math.floor(Math.random() * arr.length);
			rArr.push(arr[tmp]);
			arr.slice(tmp, 1);
		}

		return rArr;
	}

	private onclick_back() {
		console.log("back...");

		this.parent.addChild(SceneLevels.Shared());
		this.parent.removeChild(this);
	}

	// 点击字的时候，由word类调用
	public onclick_word(word: Word) {
		// 找到第一个合适的位置添加答案
		var sel: AnswerWord = null;
		for (var i = 0; i < this.group_answer.numChildren; i++) {
			var curAnswer = <AnswerWord>this.group_answer.getChildAt(i);
			if (curAnswer.SelectWord == null) {
				sel = curAnswer;

				break;
			}
		}

		if (sel != null) {
			sel.SetSelectWord(word);

			//判断是否胜利
			var check_str: string = "";
			for (var i = 0; i < this.group_answer.numChildren; i++) {
				var curAnswer = <AnswerWord>this.group_answer.getChildAt(i);
				check_str += curAnswer.getWordText();
			}

			if (check_str == LevelDataManager.Shared().GetLeve(this.levelIndex).answer) {
				//胜利
				console.log("win ...");
			}
		}
	}
}