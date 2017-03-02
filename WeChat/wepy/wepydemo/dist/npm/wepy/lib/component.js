"use strict";function _interopRequireDefault(t){return t&&t.__esModule?t:{default:t}}function _classCallCheck(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(exports,"__esModule",{value:!0});var _createClass=function(){function t(t,e){for(var i=0;i<e.length;i++){var n=e[i];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}return function(e,i,n){return i&&t(e.prototype,i),n&&t(e,n),e}}(),_typeof="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t},_event=require("./event.js"),_event2=_interopRequireDefault(_event),_util=require("./util.js"),_util2=_interopRequireDefault(_util),Props={check:function(t,e){switch(t){case String:return"string"==typeof e;case Number:return"number"==typeof e;case Boolean:return"boolean"==typeof e;case Function:return"function"==typeof e;case Object:return"object"===("undefined"==typeof e?"undefined":_typeof(e));case Array:return"[object Array]"===toString.call(e);default:return e instanceof t}},build:function(t){var e={};return"string"==typeof t?e[t]={}:"[object Array]"===toString.call(t)?t.forEach(function(t){e[t]={}}):Object.keys(t).forEach(function(i){"function"==typeof t[i]?e[i]={type:[t[i]]}:"[object Array]"===toString.call(t[i])?e[i]={type:t[i]}:e[i]=t[i],e[i].type&&"[object Array]"!==toString.call(e[i].type)&&(e[i].type=[e[i].type])}),e},valid:function t(e,i,n){var r=this,t=!1;if(e[i]){if(e[i].type)return e[i].type.some(function(t){return r.check(t,n)});t=!0}return t},getValue:function(t,e,i){var n;return n=void 0!==i&&this.valid(t,e,i)?i:"function"==typeof t[e].default?t[e].default():t[e].default,t[e].coerce?t[e].coerce(n):n}},_class=function(){function t(){_classCallCheck(this,t),this.$com={},this.$mixins=[],this.$isComponent=!0,this.$prefix="",this.$mappingProps={}}return _createClass(t,[{key:"init",value:function(t,e,i){var n=this;this.$wxpage=t,this.$isComponent&&(this.$root=e||this.$root,this.$parent=i||this.$parent,this.$wxapp=this.$root.$parent.$wxapp),this.props&&(this.props=Props.build(this.props));var r=void 0,o={},a=this.props,s=void 0,p=void 0,u=void 0;if(this.$props)for(s in this.$props)for(u in this.$props[s])/\.sync$/.test(u)&&(this.$mappingProps[this.$props[s][u]]||(this.$mappingProps[this.$props[s][u]]={}),this.$mappingProps[this.$props[s][u]][s]=u.substring(7,u.length-5));if(a)for(s in a)p=void 0,i&&i.$props&&i.$props[this.$name]&&(p=i.$props[this.$name][s],u=i.$props[this.$name]["v-bind:"+s+".once"]||i.$props[this.$name]["v-bind:"+s+".sync"],u&&(p=i[u],a[s].twoWay&&(this.$mappingProps[s]||(this.$mappingProps[s]={}),this.$mappingProps[s].parent=u))),this.data[s]||(p=Props.getValue(a,s,p),this.data[s]=p);for(r in this.data)o[""+this.$prefix+r]=this.data[r],this[r]=_util2.default.$copy(this.data[r],!0);this.setData(o);var f=Object.getOwnPropertyNames(this.$com);f.length&&f.forEach(function(t){n.$com[t].init(n.getWxPage(),e,n),n.$com[t].onLoad&&n.$com[t].onLoad(),n.$com[t].$apply()})}},{key:"initMixins",value:function(){var t=this;this.mixins?"function"==typeof this.mixins&&(this.mixins=[this.mixins]):this.mixins=[],this.mixins.forEach(function(e){var i=new e;i.init(t),t.$mixins.push(i)})}},{key:"onLoad",value:function(){}},{key:"setData",value:function(t,e){if("string"==typeof t){if(e){var i={};i[t]=e,t=i}else{var n={};n[t]=this.data[""+t],t=n}return this.$wxpage.setData(t)}var r=null,o=new RegExp("^"+this.$prefix.replace(/\$/g,"\\$"),"ig");for(r in t){var a=r.replace(o,"");this.data[a]=_util2.default.$copy(t[r],!0)}return this.$wxpage.setData(t)}},{key:"getWxPage",value:function(){return this.$wxpage}},{key:"getCurrentPages",value:function(){return this.$wxpage.getCurrentPages()}},{key:"$getComponent",value:function(t){var e=this;if("string"==typeof t){if(t.indexOf("/")===-1)return this.$com[t];if("/"===t)return this.$parent;var i=t.split("/");i.forEach(function(i,n){0===n?t=""===i?e.$root:"."===i?e:".."===i?e.$parent:e.$getComponent(i):i&&(t=t.$com[i])})}return"object"!==("undefined"==typeof t?"undefined":_typeof(t))?null:t}},{key:"$invoke",value:function(t,e){if(t=this.$getComponent(t),!t)throw new Error("Invalid path: "+t);for(var i=this.$wxpage[t.$prefix+e],n=arguments.length,r=Array(n>2?n-2:0),o=2;o<n;o++)r[o-2]=arguments[o];if("function"==typeof i){var a=new _event2.default("",this,"invoke");return i.apply(t,r.concat(a))}if(i=t[e],"function"==typeof i)return i.apply(t,r);throw new Error("Invalid method: "+e)}},{key:"$broadcast",value:function(t){for(var e=this,i="string"==typeof t?new _event2.default(t,this,"broadcast"):i,n=[e],r=arguments.length,o=Array(r>1?r-1:0),a=1;a<r;a++)o[a-1]=arguments[a];for(;n.length&&i.active;){var s=n.shift();for(var p in s.$com){p=s.$com[p],n.push(p);var u=p.events?p.events[t]:void 0;if("function"==typeof u&&u.apply(p,o.concat(i)),!i.active)break}}}},{key:"$emit",value:function(t){for(var e=this,i=this,n=new _event2.default(t,i,"emit"),r=arguments.length,o=Array(r>1?r-1:0),a=1;a<r;a++)o[a-1]=arguments[a];for(;e&&void 0!==e.$isComponent&&n.active;){var s=e.events?e.events[t]:void 0;"function"==typeof s&&s.apply(e,o.concat(n)),e=e.$parent}}},{key:"$apply",value:function(t){"function"==typeof t?(t.call(this),this.$apply()):this.$$phase?this.$$phase="$apply":this.$digest()}},{key:"$digest",value:function(){var t=this,e=void 0,i=this.data;for(this.$$phase="$digest";this.$$phase;){var n={};for(e in i)_util2.default.$isEqual(this[e],i[e])||(n[this.$prefix+e]=this[e],i[e]=_util2.default.$copy(this[e],!0),this.$mappingProps[e]&&Object.keys(this.$mappingProps[e]).forEach(function(i){var n=t.$mappingProps[e][i];"parent"!==i||_util2.default.$isEqual(t.$parent[n],t[e])?"parent"===i||_util2.default.$isEqual(t.$com[i][n],t[e])||(t.$com[i][n]=t[e],t.$com[i].$apply()):(t.$parent[n]=t[e],t.$parent.$apply())}));Object.keys(n).length&&this.setData(n),this.$$phase=!1}}}]),t}();exports.default=_class;