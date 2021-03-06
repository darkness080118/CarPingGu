G.config({
	"baseUrl": "http://sta.273.com.cn/",
	"alias": {
		"jquery": "lib/jquery/jquery-1.8.2.js",
		"underscore": "lib/underscore/underscore.js",
		"events": "lib/event/event.js",
		"widget": "lib/widget/widget.js",
		"uploader": "widget/imageUploader/image_uploader.cmb.js",
		"validator": "widget/form/form.cmb.js",
		"zepto": "lib/zepto/zepto-1.0.js"
	},
	"cacheExpire": 604800,
	"rootpaths": ["http://sta.273.com.cn/"],
	"combine": {
		"app/ms/css/basic.css": ["app/ms/css/about:blank", "app/ms/images/title_bg.gif", "app/ms/images/rp.png", "app/ms/images/title_bg2.gif", "app/ms/images/p.png", "app/ms/images/authen_icon.png", "app/ms/images/title_bg3.gif", "app/ms/images/logo.gif", "app/ms/images/m-phone.png", "app/ms/images/chart.png", "app/ms/images/tra_ad_btn_bg.gif", "app/ms/images/page404.png", "app/ms/images/dot.png", "app/ms/images/map-tips.png", "app/ms/images/map-tips-ckb.png", "app/ms/images/icons-ckb.png", "app/ms/images/icons-ckb-ie6.png", "app/ms/images/icons-7days-m.png", "app/ms/images/icons-7days-m2.png", "app/ms/images/icons-7days-l.png"],
		"app/v1/car/index.cmb.js": ["app/v1/car/brand_fast.js", "app/v1/common/index_common.js"],
		"app/v1/common/common.cmb.js": ["lib/event/event.js", "util/cookie.js", "util/url.js", "app/v1/common/log_collect.js", "app/v1/common/uuid.js", "lib/widget/widget.js", "app/v1/common/cheyou.js", "app/v1/common/common.js", "app/v1/common/header.js", "app/v1/common/bdsug.js", "app/v1/car/car.js"],
		"app/v3/js/common/common.cmb.js": ["util/cookie.js", "util/url.js", "app/v3/js/common/log_collect.js", "app/v3/js/common/common.js", "app/v3/js/common/uuid.js", "app/v3/js/common/header.js"],
		"app/v3/js/sale/list.cmb.js": ["app/v3/js/sale/search_link.js", "app/v3/js/common/jquery.scrollLoading.js"],
		"app/demo/cmb/ab.cmb.js": ["app/demo/js/a.js", "app/demo/js/b.js"],
		"widget/imageUploader/image_uploader.cmb.js": ["lib/swfobject/swfobject.js", "lib/uploader/swfupload-2.5.3.js", "lib/uploader/flash-backend.js", "lib/uploader/uploader.js", "lib/imageCroper/imageCroper.js", "widget/imageUploader/image_uploader.js"],
		"widget/form/form.cmb.js": ["lib/form/validator.js", "lib/form/field.js", "lib/form/form.js", "widget/form/form.js"],
		"app/ms/js/cmb/base.cmb.js": ["util/cookie.js", "util/storage.js", "util/winame.js", "util/uuid.js", "util/url.js", "util/log.js", "lib/event/event.js", "lib/widget/widget.js", "app/common/hover.js", "app/v3/js/common/common.js", "app/v3/js/common/header.js", "widget/autocomplete/autocomplete.js"],
		"app/ms/js/cmb/detail.cmb.js": ["app/ms/js/base.js", "lib/jquery/plugin/jquery.lazyload.js", "lib/jquery/plugin/jquery.overlay.js", "widget/map/boverlay.js", "widget/map/bmarker.js", "widget/map/bmap.js", "widget/map/map.js", "app/ms/js/detail.js"],
		"app/ms/js/cmb/index.cmb.js": ["app/ms/js/base.js", "app/ms/data/classify.js", "widget/slide/slide.js", "lib/jquery/plugin/jquery.lazyload.js", "app/ms/tpl/car_list.tpl", "app/ms/tpl/classify.tpl", "widget/map/boverlay.js", "widget/map/bmap.js", "widget/map/map.js", "widget/autocomplete/autocomplete_v2.js", "widget/autocomplete/data_source.js", "app/ms/js/index.js"],
		"app/ms/js/cmb/list.cmb.js": ["app/ms/js/base.js", "app/v3/js/common/jquery.scrollLoading.js", "app/v3/js/common/uuid.js", "app/v3/js/sale/search_link.js", "app/v3/js/common/log_collect.js", "app/v3/js/sale/list.js"],
		"app/deploy/css/bootstrap.css": ["app/deploy/fonts/glyphicons-halflings-regular.eot", "app/deploy/fonts/glyphicons-halflings-regular.eot?#iefix", "app/deploy/fonts/glyphicons-halflings-regular.woff", "app/deploy/fonts/glyphicons-halflings-regular.ttf", "app/deploy/fonts/glyphicons-halflings-regular.svg#glyphicons-halflingsregular"],
		"lib/umeditor/dialogs/emotion/emotion.css": ["lib/umeditor/dialogs/emotion/images/jxface2.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/fface.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/wface.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/tface.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/cface.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/bface.gif?v=1.1", "lib/umeditor/dialogs/emotion/images/yface.gif?v=1.1"],
		"app/distribution/js/jui/xheditor/xheditor_skin/default/ui.css": ["app/distribution/js/jui/xheditor/xheditor_skin/default/img/icons.gif", "app/distribution/js/jui/xheditor/xheditor_skin/default/img/close.gif", "app/distribution/js/jui/xheditor/xheditor_skin/default/img/waiting.gif", "app/distribution/js/jui/xheditor/xheditor_skin/default/about:blank", "app/distribution/js/jui/xheditor/xheditor_skin/default/img/progressbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/default/img/progress.gif"],
		"app/distribution/js/jui/xheditor/xheditor_skin/nostyle/ui.css": ["app/distribution/js/jui/xheditor/xheditor_skin/nostyle/img/icons.gif", "app/distribution/js/jui/xheditor/xheditor_skin/nostyle/img/close.gif", "app/distribution/js/jui/xheditor/xheditor_skin/nostyle/img/waiting.gif", "app/distribution/js/jui/xheditor/xheditor_skin/nostyle/about:blank", "app/distribution/js/jui/xheditor/xheditor_skin/nostyle/img/progressbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/nostyle/img/progress.gif"],
		"app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/ui.css": ["app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/buttonbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/icons.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/close.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/waiting.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/about:blank", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/progressbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007blue/img/progress.gif"],
		"app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/ui.css": ["app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/buttonbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/icons.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/close.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/waiting.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/about:blank", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/progressbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/o2007silver/img/progress.gif"],
		"app/distribution/js/jui/xheditor/xheditor_skin/vista/ui.css": ["app/distribution/js/jui/xheditor/xheditor_skin/vista/img/buttonbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/icons.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/titlebg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/close.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/waiting.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/about:blank", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/progressbg.gif", "app/distribution/js/jui/xheditor/xheditor_skin/vista/img/progress.gif"],
		"app/evaluate/js/cmb/index.cmb.js": ["app/ms/js/base.js", "app/common/vehicle2/vehicle.js", "app/common/vehicle2/vehicle.tpl", "widget/autocomplete/autocomplete_v2.js", "widget/autocomplete/data_source.js", "widget/position/position.js", "app/common/eval_form.js", "app/evaluate/js/index.js"],
		"app/evaluate/js/cmb/result.cmb.js": ["app/ms/js/base.js", "lib/jquery/plugin/jquery.overlay.js", "app/evaluate/js/result.js"],
		"app/ms_v2/css/basic.css": ["app/ms_v2/css/about:blank", "app/ms_v2/images/icons.png", "app/ms_v2/images/icons_gif.gif", "app/ms_v2/images/logo.png", "app/ms_v2/pics/code_index_app_down.jpg", "app/ms_v2/images/title1_bg.png", "app/ms_v2/images/services_bg.png", "app/ms_v2/images/baoxiu_png24.png", "app/ms_v2/images/ckb-ico.png", "app/ms_v2/images/share_icon.png", "app/ms_v2/images/loading.gif"],
		"app/ms_v2/js/cmb/base.cmb.js": ["util/cookie.js", "util/storage.js", "util/log_v2.js", "util/url.js", "util/uuid_v2.js", "util/winame.js", "lib/widget/widget.js", "lib/event/event.js", "lib/jquery/plugin/jquery.lazyload.js", "widget/autocomplete/autocomplete_v2.js", "widget/autocomplete/data_source.js", "app/v3/js/common/common.js", "app/v3/js/common/header.js", "app/common/hover.js", "app/ms_v2/js/base.js"],
		"app/ms_v2/js/cmb/detail.cmb.js": ["widget/map/map.js", "widget/map/bmap.js", "widget/map/bmarker.js", "widget/map/boverlay.js", "widget/position/position.js", "widget/imageSlide/image_slide.js", "lib/jquery/plugin/jquery.overlay.js", "app/ms_v2/js/detail.js", "app/ms_v2/js/common/show_comment.js"],
		"app/ms_v2/js/cmb/index.cmb.js": ["widget/map/map.js", "widget/map/bmap.js", "widget/map/boverlay.js", "app/ms_v2/js/index.js", "app/ms_v2/js/common/slide.js", "lib/jquery/plugin/scrollPane/jquery.scrollpane.js", "lib/jquery/plugin/scrollPane/jquery.mousewheel.js", "app/common/key_contorl.js"],
		"app/ms_v2/js/cmb/list.cmb.js": ["widget/position/position.js", "app/common/key_contorl.js", "app/ms_v2/js/common/more_list.js", "app/ms_v2/js/list.js", "widget/dialog/dialog.js", "widget/mask/mask.js", "app/ms_v2/js/common/list_filters.js"],
		"app/evaluate/js/cmb/detail.cmb.js": ["app/ms/js/base.js", "lib/jquery/plugin/jquery.overlay.js", "app/evaluate/js/detail.js"],
		"app/evaluate/js/cmb/list.cmb.js": ["app/evaluate/js/list.js"],
		"app/wap_v2/js/cmb/base.cmb.js": ["util/cookie.js", "util/storage.js", "util/winame.js", "util/url.js", "util/uuid.js", "lib/event/event.js", "lib/underscore/underscore.js", "app/wap_v2/js/util/overlay.js", "app/wap_v2/js/util/log.js", "app/wap_v2/js/common/widget.js", "app/wap_v2/js/common/common.js", "app/wap_v2/js/common/footer.js", "app/wap_v2/js/sale/base.js"],
		"app/wap_v2/js/cmb/index.cmb.js": ["app/wap_v2/js/common/autocomplete.js", "app/wap_v2/js/sale/matchBox.js", "app/wap_v2/js/util/swipe.js", "app/wap_v2/js/sale/index.js"],
		"app/chain/js/cmb/base.cmb.js": ["util/cookie.js", "util/storage.js", "util/log_v2.js", "util/url.js", "util/uuid_v2.js", "util/winame.js", "lib/widget/widget.js", "lib/event/event.js", "lib/jquery/plugin/jquery.lazyload.js", "widget/autocomplete/autocomplete_v2.js", "widget/autocomplete/data_source.js", "app/common/hover.js", "app/ms_v2/js/base.js", "app/chain/js/header.js", "app/chain/tpl/shop_map.tpl", "widget/map/bmap.js", "widget/map/boverlay.js", "widget/map/map.js"],
		"app/chain/js/cmb/shop_index.cmb.js": ["app/chain/js/shop_index.js", "widget/slide/chainSlide/slide.js"],
		"app/common/location/location.cmb.js": ["app/common/location/location.js", "app/common/location/location_event.js", "util/data_cache.js"],
		"app/mbs/css/lightbox.css": ["app/mbs/img/close.png", "app/mbs/img/loading.gif", "app/mbs/img/prev.png", "app/mbs/img/next.png", "app/mbs/css/data:image/gif;base6"],
		"widget/fileupload/fileupload.css": ["widget/fileupload/data:image/gif;base64", "widget/fileupload/img/success.png", "widget/fileupload/img/delete_white.png"],
		"app/zt/market/js/slider/dist/index.css": ["app/zt/market/js/slider/dist/data:image/gif;base64"],
		"widget/mobiscroll/css/mobiscroll.custom-2.16.1.min.css": ["widget/mobiscroll/css/icons_mobiscroll.eot?rze99w", "widget/mobiscroll/css/icons_mobiscroll.eot?#iefixrze99w", "widget/mobiscroll/css/data:application/ttf;base64", "widget/mobiscroll/css/data:application/x-font-woff;base64", "widget/mobiscroll/css/icons_mobiscroll.svg?992i1i#icons_mobiscroll"],
		"app/ms_v2/js/cmb/index_v4.cmb.js": ["util/cookie.js", "util/log_v2.js", "util/url.js", "util/uuid_v2.js", "util/winame.js", "lib/widget/widget.js", "lib/event/event.js", "lib/jquery/plugin/jquery.lazyload.js", "lib/class/class.js", "lib/class/event.js", "lib/class/index.js", "widget/map/map.js", "widget/map/bmap.js", "widget/map/boverlay.js", "widget/slide/slide.js", "widget/autocomplete_v4/autocomplete.js", "widget/tabs/tabs.js", "app/ms_v2/tpl/car.tpl", "app/ms_v2/js/index_v4.js"],
		"widget/fileupload/fileupload2.css": ["widget/fileupload/data:image/gif;base64", "widget/fileupload/img/success.png", "widget/fileupload/img/close.png"],
		"app/web_mobile/careasy/css/fileupload.css": ["app/web_mobile/careasy/css/data:image/gif;base64", "app/web_mobile/img/chejiandan/success.png", "app/web_mobile/img/chejiandan/delete_white.png"],
		"app/mbs/datetimepicker/jquery.datetimepicker.css": ["app/mbs/datetimepicker/data:image/png;base64"]
	},
	"version": {
		"data/location/location.js": 1475198406,
		"config.json": 1475198407,
		"config.js": 1475198407
	}
});
G.config({
	versionTemplate: function anonymous(obj) {
		var p = [],
			print = function() {
				p.push.apply(p, arguments);
			};
		with(obj) {
			p.push('', url.href.replace(url.ext, '.__' + version + '__' + url.ext), '');
		}
		return p.join('');
	}
});