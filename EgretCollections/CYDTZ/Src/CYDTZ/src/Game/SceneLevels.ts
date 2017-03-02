/**
 *
 * @author 
 *
 */
class SceneLevels extends eui.Component {

	// 单例
	private static shared: SceneLevels;
	public static Shared() {
		if (SceneLevels.shared == null) {
			SceneLevels.shared = new SceneLevels();
		}

		return SceneLevels.shared;
	}

	private btn_back: eui.Button;
	private group_levels: eui.Group;
	private img_arrow: eui.Image;
	private tlb: eui.Label;
	private SelLevel: number = 0;
	private LevelIcons: LevelIcon[] = [];

	public constructor() {
		super();

		this.skinName = "src/Game/SceneLevelsSkin.exml";
		this.btn_back.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_back, this);

		// 地图选项
		var row = 20;
		var col = 20;
		var spanx = 720 / col;
		var spany = 1136 / row;
		var count = 100;	//TODO:此值过大时，会出现异常

		var groupBk = new eui.Group(); // 背景
		groupBk.width = 720;
		groupBk.height = (spany * count);

		// 背景图 
		for (var i = 0; i < (groupBk.height / 1136); i++) {
			var img = new eui.Image();
			img.source = RES.getRes("GameBG2_jpg");
			img.y = i * 1136;
			img.touchEnabled = false;
			this.group_levels.addChildAt(img, 0);
		}

		// 正弦方式绘制关卡图标
		var milestone: number = LevelDataManager.Shared().Milestone;
		for (var i = 0; i < count; i++) {
			var icon = new LevelIcon();
			icon.Level = i + 1;

			icon.y = spany * i / 2;
			icon.x = Math.sin(icon.y / 180 * Math.PI) * 200 + groupBk.width / 2;
			icon.y += spany * i / 2;
			icon.y = groupBk.height - icon.y - spany;

			icon.x = Math.floor(icon.x);
			icon.y = Math.floor(icon.y);

			console.log("icon:level=" + icon.Level + ",x=" + icon.x + ",y=" + icon.y);
			groupBk.addChild(icon);
			icon.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_level, this);

			icon.enabled = i < milestone;
			this.LevelIcons.push(icon);
		}

		console.log("groupbk:width=" + groupBk.width + ",height=" + groupBk.height);

		// var c=0;
		// for (var i = 0; i < 20; i++) {
		// 	for (var j = 0; j < 20; j++) {
		// 		var icon = new LevelIcon();
		// 		icon.Level = c++;

		// 		icon.y = spany * (c / row);
		// 		icon.x = spanx * (c % col);

		// 		console.log("icon:level=" + icon.Level + ",x=" + icon.x + ",y=" + icon.y);
		// 		groupBk.addChild(icon);
		// 		icon.addEventListener(egret.TouchEvent.TOUCH_TAP, this.onclick_level, this);
		// 	}
		// }

		// 开启位图缓存模式
		groupBk.cacheAsBitmap = true;
		this.group_levels.addChild(groupBk);

		// 卷动到最底层
		this.group_levels.scrollV = groupBk.height - 1100;

		// 随动鼠标图标
		this.img_arrow = new eui.Image();
		this.img_arrow.source = RES.getRes("PageDownBtn_png");
		this.img_arrow.anchorOffsetX = 124 / 2 - groupBk.getChildAt(0).width / 2;
		this.img_arrow.anchorOffsetY = 76;
		this.img_arrow.touchEnabled = false;
		this.img_arrow.x = groupBk.getChildAt(0).x;
		this.img_arrow.y = groupBk.getChildAt(0).y;

		groupBk.addChild(this.img_arrow);

		this.tlb = new eui.Label();
		//调试使用： groupBk.addChild(this.tlb);
	}

	// back button
	private onclick_back() {
		console.log("return start page ....");

		this.parent.addChild(SceneBegin.Shared());
		this.parent.removeChild(this);
	}

	// 选关
	private onclick_level(e: egret.TouchEvent) {
		var icon = <LevelIcon>e.currentTarget;
		console.log(icon.Level);

		if (this.SelLevel != icon.Level) {
			this.img_arrow.x = icon.x;
			this.img_arrow.y = icon.y;

			this.tlb.text = icon.Level.toString();
			this.tlb.x = icon.x;
			this.tlb.y = icon.y;

			this.SelLevel = icon.Level;
		} else {
			//TODO:开始游戏
		}
	}

	public OpenLevel(level:number) {
		var icon = this.LevelIcons[level-1];
		icon.enabled = true;
		if (level>LevelDataManager.Shared().Milestone) {
			LevelDataManager.Shared().Milestone = level;

			// 选定标记
			this.img_arrow.x = icon.x;
			this.img_arrow.y = icon.y;
			this.SelLevel = icon.Level;
		}
	}
}
