(function(t){function e(e){for(var n,i,c=e[0],l=e[1],o=e[2],d=0,f=[];d<c.length;d++)i=c[d],a[i]&&f.push(a[i][0]),a[i]=0;for(n in l)Object.prototype.hasOwnProperty.call(l,n)&&(t[n]=l[n]);u&&u(e);while(f.length)f.shift()();return r.push.apply(r,o||[]),s()}function s(){for(var t,e=0;e<r.length;e++){for(var s=r[e],n=!0,c=1;c<s.length;c++){var l=s[c];0!==a[l]&&(n=!1)}n&&(r.splice(e--,1),t=i(i.s=s[0]))}return t}var n={},a={app:0},r=[];function i(e){if(n[e])return n[e].exports;var s=n[e]={i:e,l:!1,exports:{}};return t[e].call(s.exports,s,s.exports,i),s.l=!0,s.exports}i.m=t,i.c=n,i.d=function(t,e,s){i.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:s})},i.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},i.t=function(t,e){if(1&e&&(t=i(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var s=Object.create(null);if(i.r(s),Object.defineProperty(s,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var n in t)i.d(s,n,function(e){return t[e]}.bind(null,n));return s},i.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return i.d(e,"a",e),e},i.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},i.p="/";var c=window["webpackJsonp"]=window["webpackJsonp"]||[],l=c.push.bind(c);c.push=e,c=c.slice();for(var o=0;o<c.length;o++)e(c[o]);var u=l;r.push([0,"chunk-vendors"]),s()})({0:function(t,e,s){t.exports=s("56d7")},"034f":function(t,e,s){"use strict";var n=s("c21b"),a=s.n(n);a.a},"1acb":function(t,e,s){var n={"./af":"2d5e","./af.js":"2d5e","./ar":"23b0","./ar-dz":"80ec","./ar-dz.js":"80ec","./ar-kw":"688b","./ar-kw.js":"688b","./ar-ly":"386a","./ar-ly.js":"386a","./ar-ma":"318b","./ar-ma.js":"318b","./ar-sa":"101d","./ar-sa.js":"101d","./ar-tn":"821f","./ar-tn.js":"821f","./ar.js":"23b0","./az":"6597","./az.js":"6597","./be":"6878","./be.js":"6878","./bg":"b3c7","./bg.js":"b3c7","./bm":"2a29","./bm.js":"2a29","./bn":"77c2","./bn.js":"77c2","./bo":"e20a","./bo.js":"e20a","./br":"3d0b","./br.js":"3d0b","./bs":"f0f1","./bs.js":"f0f1","./ca":"3b52","./ca.js":"3b52","./cs":"cb09","./cs.js":"cb09","./cv":"a790","./cv.js":"a790","./cy":"6b24","./cy.js":"6b24","./da":"5671","./da.js":"5671","./de":"e5a9","./de-at":"96a6","./de-at.js":"96a6","./de-ch":"b56c","./de-ch.js":"b56c","./de.js":"e5a9","./dv":"d26d","./dv.js":"d26d","./el":"df2b","./el.js":"df2b","./en-au":"9719","./en-au.js":"9719","./en-ca":"ef3b","./en-ca.js":"ef3b","./en-gb":"0f46","./en-gb.js":"0f46","./en-ie":"466b","./en-ie.js":"466b","./en-il":"c5a1","./en-il.js":"c5a1","./en-nz":"1f77","./en-nz.js":"1f77","./eo":"82da","./eo.js":"82da","./es":"5137","./es-do":"f782","./es-do.js":"f782","./es-us":"5c3b","./es-us.js":"5c3b","./es.js":"5137","./et":"81e3","./et.js":"81e3","./eu":"366f","./eu.js":"366f","./fa":"93b6","./fa.js":"93b6","./fi":"3509","./fi.js":"3509","./fo":"301b","./fo.js":"301b","./fr":"7989","./fr-ca":"0f2d","./fr-ca.js":"0f2d","./fr-ch":"0c2c","./fr-ch.js":"0c2c","./fr.js":"7989","./fy":"280a","./fy.js":"280a","./gd":"b081","./gd.js":"b081","./gl":"4bee","./gl.js":"4bee","./gom-latn":"f8bb","./gom-latn.js":"f8bb","./gu":"e2c9","./gu.js":"e2c9","./he":"ada2","./he.js":"ada2","./hi":"d754","./hi.js":"d754","./hr":"8a3a","./hr.js":"8a3a","./hu":"81f7","./hu.js":"81f7","./hy-am":"1bdb","./hy-am.js":"1bdb","./id":"89c9","./id.js":"89c9","./is":"67b4","./is.js":"67b4","./it":"468c","./it.js":"468c","./ja":"c617","./ja.js":"c617","./jv":"7756","./jv.js":"7756","./ka":"d568","./ka.js":"d568","./kk":"87ad","./kk.js":"87ad","./km":"9db3","./km.js":"9db3","./kn":"ed86","./kn.js":"ed86","./ko":"60ac","./ko.js":"60ac","./ky":"c52b","./ky.js":"c52b","./lb":"58d1","./lb.js":"58d1","./lo":"4b1a","./lo.js":"4b1a","./lt":"5b29","./lt.js":"5b29","./lv":"94a6","./lv.js":"94a6","./me":"22ad","./me.js":"22ad","./mi":"f6b3","./mi.js":"f6b3","./mk":"d73e","./mk.js":"d73e","./ml":"e5bd","./ml.js":"e5bd","./mn":"0656","./mn.js":"0656","./mr":"9b87","./mr.js":"9b87","./ms":"4326","./ms-my":"1cc4","./ms-my.js":"1cc4","./ms.js":"4326","./mt":"dde2","./mt.js":"dde2","./my":"a784","./my.js":"a784","./nb":"27bc","./nb.js":"27bc","./ne":"08e1","./ne.js":"08e1","./nl":"271b","./nl-be":"f589","./nl-be.js":"f589","./nl.js":"271b","./nn":"0aa2","./nn.js":"0aa2","./pa-in":"a117","./pa-in.js":"a117","./pl":"f679","./pl.js":"f679","./pt":"3fe0","./pt-br":"a8c6","./pt-br.js":"a8c6","./pt.js":"3fe0","./ro":"39a0","./ro.js":"39a0","./ru":"8161","./ru.js":"8161","./sd":"7b16","./sd.js":"7b16","./se":"127c","./se.js":"127c","./si":"8a25","./si.js":"8a25","./sk":"87e5","./sk.js":"87e5","./sl":"7caa","./sl.js":"7caa","./sq":"7b6f","./sq.js":"7b6f","./sr":"97f6","./sr-cyrl":"717c","./sr-cyrl.js":"717c","./sr.js":"97f6","./ss":"1e96","./ss.js":"1e96","./sv":"36b1","./sv.js":"36b1","./sw":"62de","./sw.js":"62de","./ta":"4a83","./ta.js":"4a83","./te":"1687","./te.js":"1687","./tet":"6a50","./tet.js":"6a50","./tg":"c2a8","./tg.js":"c2a8","./th":"4962","./th.js":"4962","./tl-ph":"c9cd","./tl-ph.js":"c9cd","./tlh":"9995","./tlh.js":"9995","./tr":"b8ab","./tr.js":"b8ab","./tzl":"5dda","./tzl.js":"5dda","./tzm":"7461","./tzm-latn":"132c","./tzm-latn.js":"132c","./tzm.js":"7461","./ug-cn":"9b5a","./ug-cn.js":"9b5a","./uk":"35c4","./uk.js":"35c4","./ur":"9b6a","./ur.js":"9b6a","./uz":"6eac","./uz-latn":"0154","./uz-latn.js":"0154","./uz.js":"6eac","./vi":"835e","./vi.js":"835e","./x-pseudo":"fc52","./x-pseudo.js":"fc52","./yo":"2377","./yo.js":"2377","./zh-cn":"a55f","./zh-cn.js":"a55f","./zh-hk":"5d2d","./zh-hk.js":"5d2d","./zh-tw":"1f07","./zh-tw.js":"1f07"};function a(t){var e=r(t);return s(e)}function r(t){var e=n[t];if(!(e+1)){var s=new Error("Cannot find module '"+t+"'");throw s.code="MODULE_NOT_FOUND",s}return e}a.keys=function(){return Object.keys(n)},a.resolve=r,t.exports=a,a.id="1acb"},"1c97":function(t,e,s){},"56d7":function(t,e,s){"use strict";s.r(e);s("cadf"),s("551c"),s("097d");var n=s("2b0e"),a=function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("v-app",{attrs:{id:"app",dark:""}},[s("v-navigation-drawer",{attrs:{fixed:"",right:"",width:"375",app:""}},[s("TruckList",{attrs:{trucks:t.trucks}})],1),s("v-content",[s("v-container",[s("StatusBoard",{attrs:{trucks:t.trucks,mostRecent:t.mostRecent}})],1)],1)],1)},r=[],i=(s("6b54"),function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",[s("v-list",{attrs:{"three-line":"",dense:""}},[s("v-list-tile",[s("v-list-tile-title",{staticClass:"title"},[t._v("\n          Active Trucks\n        ")])],1),t._l(t.trucks,function(e){return s("v-list-tile",{key:e.truckId,staticClass:"truckItem mb-4"},[s("v-flex",{attrs:{xs12:""}},[s("v-card",{staticClass:"pa-2",attrs:{color:"deep-purple darken-4"}},[s("v-list-tile-content",[s("v-list-tile-title",[t._v("Truck Id: "+t._s(e.truckId)+", "+t._s(e.pallets)+" Pallets")]),s("v-list-tile-sub-title",[t._v("Last Event: \n                "),null!=e.dockEndTime?s("span",[t._v("Left Dock at "+t._s(t._f("formatDate")(e.dockEndTime)))]):null!=e.unloadStopTime?s("span",[t._v("Unload completed at "+t._s(t._f("formatDate")(e.unloadStopTime)))]):null!=e.unloadStartTime?s("span",[t._v("Unload began at "+t._s(t._f("formatDate")(e.unloadStartTime)))]):null!=e.dockStartTime?s("span",[t._v("Entered dock at "+t._s(t._f("formatDate")(e.dockStartTime)))]):s("span",[t._v("Entered DC at "+t._s(t._f("formatDate")(e.enterDCTime)))])]),null!=e.unloadStartTime&&null==e.unloadStopTime?s("v-list-tile-sub-title",[s("span",[t._v("Unload Time: "),s("timer",{attrs:{countFrom:e.unloadStartTime}})],1)]):t._e(),s("v-list-tile-sub-title",[t._v("\n                Total Time: "),s("timer",{attrs:{countFrom:e.enterDCTime}})],1),s("v-divider",{attrs:{light:""}}),s("v-spacer")],1)],1)],1)],1)})],2)],1)}),c=[],l=(s("c5f6"),s("05b9")),o=s.n(l),u=function(){var t=this,e=t.$createElement,s=t._self._c||e;return t.countFrom?s("span",[t._v(t._s(t._f("formatDuration")(this.now-new Date(t.countFrom+"Z"))))]):t._e()},d=[],f={name:"Timer",props:{countFrom:null},data:function(){return{interval:null,now:null}},mounted:function(){this.interval=setInterval(this.onTimer,1e3)},methods:{onTimer:function(){this.now=Date.now()}}},v=f,b=s("2877"),m=Object(b["a"])(v,u,d,!1,null,null,null);m.options.__file="Timer.vue";var j=m.exports,p={name:"TruckList",components:{Timer:j},props:{trucks:{truckId:Number}}},_=p,k=(s("8baf"),Object(b["a"])(_,i,c,!1,null,null,null));k.options.__file="TruckList.vue";var h=k.exports,g=function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("v-container",{attrs:{"grid-list-md":"","text-xs-center":""}},[s("v-layout",{attrs:{row:"",wrap:"",float:""}},[s("v-flex",{attrs:{xs2:""}},[t.mostRecent?s("v-card",[s("v-card-title",[t._v("\n                     Last Event:\n                 ")]),s("v-divider"),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("Truck Id:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t.mostRecent.truckId))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("On Location:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.enterDCTime)))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("OnDock:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.dockStartTime)))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("Unloading:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.unloadStartTime)))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("Unload Complete:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.unloadStopTime)))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("Left Dock:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.dockEndTime)))])],1)],1),s("v-list",{attrs:{dense:""}},[s("v-list-tile",[s("v-list-tile-content",[t._v("Left Location:")]),s("v-list-tile-content",{staticClass:"align-end"},[t._v(t._s(t._f("formatDate")(t.mostRecent.leaveDCTime)))])],1)],1)],1):t._e()],1),s("v-flex",{attrs:{xs2:""}},[s("v-card",[s("v-card-title",[t._v("\n                     On Location:\n                 ")]),s("v-divider"),s("v-card-text",{staticClass:"display-4"},[t._v(t._s(t.getCount(1,t.trucks)))])],1)],1),s("v-flex",{attrs:{xs2:""}},[s("v-card",[s("v-card-title",[t._v("\n                     On Dock:\n                 ")]),s("v-divider"),s("v-card-text",{staticClass:"display-4"},[t._v(t._s(t.getCount(2,t.trucks)))])],1)],1),s("v-flex",{attrs:{xs2:""}},[s("v-card",[s("v-card-title",[t._v("\n                     Unloading:\n                 ")]),s("v-divider"),s("v-card-text",{staticClass:"display-4"},[t._v(t._s(t.getCount(3,t.trucks)))])],1)],1),s("v-flex",{attrs:{xs2:""}},[s("v-card",[s("v-card-title",[t._v("\n                     Unloading Complete:\n                 ")]),s("v-divider"),s("v-card-text",{staticClass:"display-4"},[t._v(t._s(t.getCount(4,t.trucks)))])],1)],1),s("v-flex",{attrs:{xs2:""}},[s("v-card",[s("v-card-title",[t._v("\n                     Left Dock:\n                 ")]),s("v-divider"),s("v-card-text",{staticClass:"display-4"},[t._v(t._s(t.getCount(5,t.trucks)))])],1)],1)],1)],1)},y=[],T={name:"StatusBoard",components:{Timer:j},props:{trucks:{truckId:Number},mostRecent:null},methods:{getCount:function(t,e){var s=0;if(e)for(var n=0;n<e.length;n++)e[n].status==t&&s++;return s}}},x=T,w=Object(b["a"])(x,g,y,!1,null,null,null);w.options.__file="StatusBoard.vue";var C=w.exports,D=s("bc3a"),z=s.n(D),S=s("5c22"),O={name:"app",components:{TruckList:h,StatusBoard:C},mounted:function(){var t=this;z.a.get("https://nrtdemoweb.azurewebsites.net/api/truck").then(function(e){return t.trucks=e.data});var e=this,s=(new S.HubConnectionBuilder).withUrl("https://nrtdemoweb.azurewebsites.net/truckHub").configureLogging(S.LogLevel.Information).build();s.start().catch(function(t){return console.error(t.toString())}),s.on("SendMessage",function(t,s){e.processTruck(t,s)})},data:function(){return{trucks:null,mostRecent:null}},methods:{processTruck:function(t,e){for(var s=0;s<this.trucks.length;s++)if(this.trucks[s].truckId==t)return console.log(e),e.leaveDCTime?this.trucks.splice(s,1):this.trucks.splice(s,1,e),this.mostRecent=e,void(this.mostRecent.truckId=t);this.trucks.push(e),this.mostRecent=e,this.mostRecent.truckId=t,console.log(e)}}},L=O,R=(s("034f"),Object(b["a"])(L,a,r,!1,null,null,null));R.options.__file="App.vue";var E=R.exports,I=s("ce5b"),U=s.n(I);s("953f");n["default"].use(U.a),n["default"].config.productionTip=!1,n["default"].filter("formatDate",function(t){if(t)return o.a.utc(String(t)).local().format("MM/DD/YYYY hh:mm")}),n["default"].filter("formatDuration",function(t){if(t)return o.a.utc(t).format("HH:mm:ss")}),new n["default"]({render:function(t){return t(E)}}).$mount("#app")},"8baf":function(t,e,s){"use strict";var n=s("1c97"),a=s.n(n);a.a},c21b:function(t,e,s){}});
//# sourceMappingURL=app.bd216057.js.map