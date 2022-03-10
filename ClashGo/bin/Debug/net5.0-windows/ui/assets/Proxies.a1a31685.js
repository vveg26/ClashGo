import{r as o,j as m,g as E,C as Pe,V as Se,Z as k,k as $,R as P,W as Re,M as Ae,T as Te}from"./vendor.ba31f7a6.js";import{B as x,E as Me,F as V,N as K,c as _,G as Z,H as I,k as S,I as Le,J as Y,K as z,L as B,M as Ne,O as De,P as Fe,Q as J,R as $e,g as Q,C as X,l as ee,T as Ie,m as te,U as ze,V as Be,W as qe,X as je}from"./index.5c77d412.js";import{F as He,p as We,A as Ge,I as Ue}from"./Fab.a9ba0fd2.js";import{R as Ve,T as Ke}from"./TextFitler.f6dcd16e.js";import{f as Ze}from"./index.9233837d.js";import{S as Ye}from"./Select.9719ad7f.js";import"./debounce.76599460.js";const Je="_FlexCenter_1380a_1";var Qe={FlexCenter:Je};function Xe({children:e}){return o.exports.createElement("div",{className:Qe.FlexCenter},e)}const{useRef:re,useEffect:et}=m;function tt({onClickPrimaryButton:e,onClickSecondaryButton:t}){const r=re(null),n=re(null);et(()=>{r.current.focus()},[]);const s=a=>{a.keyCode===39?n.current.focus():a.keyCode===37&&r.current.focus()};return o.exports.createElement("div",{onKeyDown:s},o.exports.createElement("h2",null,"Close Connections?"),o.exports.createElement("p",null,'Click "Yes" to close those connections that are still using the old selected proxy in this group'),o.exports.createElement("div",{style:{height:30}}),o.exports.createElement(Xe,null,o.exports.createElement(x,{onClick:e,ref:r},"Yes"),o.exports.createElement("div",{style:{width:20}}),o.exports.createElement(x,{onClick:t,ref:n},"No")))}const rt="_header_1y9js_1",nt="_arrow_1y9js_8",ot="_isOpen_1y9js_13",st="_btn_1y9js_20",at="_qty_1y9js_25";var g={header:rt,arrow:nt,isOpen:ot,btn:st,qty:at};function ne({name:e,type:t,toggle:r,isOpen:n,qty:s}){const a=o.exports.useCallback(i=>{i.preventDefault(),(i.key==="Enter"||i.key===" ")&&r()},[r]);return o.exports.createElement("div",{className:g.header,onClick:r,style:{cursor:"pointer"},tabIndex:0,onKeyDown:a,role:"button"},o.exports.createElement("div",null,o.exports.createElement(Me,{name:e,type:t})),typeof s=="number"?o.exports.createElement("span",{className:g.qty},s):null,o.exports.createElement(x,{kind:"minimal",onClick:r,className:g.btn,title:"Toggle collapsible section"},o.exports.createElement("span",{className:E(g.arrow,{[g.isOpen]:n})},o.exports.createElement(Pe,{size:20}))))}const{useMemo:it}=m;function ct(e,t){return e.filter(r=>{const n=t[r];return n===void 0?!0:n.number!==0})}const R=(e,t)=>{if(e&&typeof e.number=="number"&&e.number>0)return e.number;const r=t&&t.type;return r&&K.indexOf(r)>-1?-1:999999},lt={Natural:e=>e,LatencyAsc:(e,t,r)=>e.sort((n,s)=>{const a=R(t[n],r&&r[n]),i=R(t[s],r&&r[s]);return a-i}),LatencyDesc:(e,t,r)=>e.sort((n,s)=>{const a=R(t[n],r&&r[n]);return R(t[s],r&&r[s])-a}),NameAsc:e=>e.sort(),NameDesc:e=>e.sort((t,r)=>t>r?-1:t<r?1:0)};function ut(e,t){const r=t.toLowerCase().split(" ").map(n=>n.trim()).filter(n=>!!n);return r.length===0?e:e.filter(n=>{let s=0;for(;s<r.length;s++){const a=r[s];if(n.toLowerCase().indexOf(a)>-1)return!0}return!1})}function pt(e,t,r,n,s,a){let i=[...e];return r&&(i=ct(e,t)),typeof n=="string"&&n!==""&&(i=ut(i,n)),lt[s](i,t,a)}function oe(e,t,r,n,s){const[a]=Se(V);return it(()=>pt(e,t,r,a,n,s),[e,t,r,a,n,s])}const dt="_header_1g0y5_1",ft="_zapWrapper_1g0y5_5";var se={header:dt,zapWrapper:ft};const ae={Right:39,Left:37,Enter:13,Space:32},mt="_proxy_sq0tg_1",ht="_now_sq0tg_25",vt="_error_sq0tg_29",yt="_selectable_sq0tg_32",xt="_proxyType_sq0tg_40",_t="_row_sq0tg_51",bt="_proxyName_sq0tg_57",Et="_proxySmall_sq0tg_68";var h={proxy:mt,now:ht,error:vt,selectable:yt,proxyType:xt,row:_t,proxyName:bt,proxySmall:Et};const gt="_proxyLatency_15kyb_1";var wt={proxyLatency:gt};function Ct({number:e,color:t}){return o.exports.createElement("span",{className:wt.proxyLatency,style:{color:t}},o.exports.createElement("span",null,e," ms"))}const{useMemo:w}=m,C={good:"#67c23a",normal:"#d4b75c",bad:"#e67f3c",na:"#909399"};function ie({number:e}={}){return e===0?C.na:e<200?C.good:e<400?C.normal:typeof e=="number"?C.bad:C.na}function Ot(e,t){return K.indexOf(t)>-1?"linear-gradient(135deg, white 15%, #999 15% 30%, white 30% 45%, #999 45% 60%, white 60% 75%, #999 75% 90%, white 90% 100%)":ie(e)}function kt({now:e,name:t,proxy:r,latency:n,isSelectable:s,onClick:a}){const i=w(()=>Ot(n,r.type),[n,r]),c=w(()=>{let d=t;return n&&typeof n.number=="number"&&(d+=" "+n.number+" ms"),d},[t,n]),l=o.exports.useCallback(()=>{s&&a&&a(t)},[t,a,s]),u=w(()=>E(h.proxySmall,{[h.now]:e,[h.selectable]:s}),[s,e]),p=o.exports.useCallback(d=>{d.keyCode===ae.Enter&&l()},[l]);return o.exports.createElement("div",{title:c,className:u,style:{background:i},onClick:l,onKeyDown:p,role:s?"menuitem":""})}function Pt(e){return e==="Shadowsocks"?"SS":e}function St({now:e,name:t,proxy:r,latency:n,isSelectable:s,onClick:a}){const i=w(()=>ie(n),[n]),c=o.exports.useCallback(()=>{s&&a&&a(t)},[t,a,s]),l=o.exports.useCallback(p=>{p.keyCode===ae.Enter&&c()},[c]),u=w(()=>E(h.proxy,{[h.now]:e,[h.error]:n&&n.error,[h.selectable]:s}),[s,e,n]);return o.exports.createElement("div",{tabIndex:0,className:u,onClick:c,onKeyDown:l,role:s?"menuitem":""},o.exports.createElement("div",{className:h.proxyName},t),o.exports.createElement("div",{className:h.row},o.exports.createElement("span",{className:h.proxyType,style:{opacity:e?.6:.2}},Pt(r.type)),n&&n.number?o.exports.createElement(Ct,{number:n.number,color:i}):null))}const ce=(e,{name:t})=>{const r=Z(e),n=I(e);return{proxy:r[t],latency:n[t]}},Rt=_(ce)(St),At=_(ce)(kt),Tt="_list_10y5m_1",Mt="_listSummaryView_10y5m_8";var le={list:Tt,listSummaryView:Mt};function ue({all:e,now:t,isSelectable:r,itemOnTapCallback:n}){const s=e;return o.exports.createElement("div",{className:le.list},s.map(a=>o.exports.createElement(Rt,{key:a,onClick:n,isSelectable:r,name:a,now:a===t})))}function pe({all:e,now:t,isSelectable:r,itemOnTapCallback:n}){return o.exports.createElement("div",{className:le.listSummaryView},e.map(s=>o.exports.createElement(At,{key:s,onClick:n,isSelectable:r,name:s,now:s===t})))}const{createElement:Lt,useCallback:q,useMemo:Nt,useState:Dt}=m;function Ft(){return o.exports.createElement("div",{className:se.zapWrapper},o.exports.createElement(k,{size:16}))}function $t({name:e,all:t,delay:r,hideUnavailableProxies:n,proxySortBy:s,proxies:a,type:i,now:c,isOpen:l,apiConfig:u,dispatch:p}){const d=oe(t,r,n,s,a),v=Nt(()=>i==="Selector",[i]),{app:{updateCollapsibleIsOpen:y},proxies:{requestDelayForProxies:f}}=S(),O=q(()=>{y("proxyGroup",e,!l)},[l,y,e]),D=q(U=>{!v||p(Le(u,e,U))},[u,p,e,v]),[F,G]=Dt(!1),ke=q(async()=>{G(!0);try{await f(u,d)}catch{}G(!1)},[d,u,f]);return o.exports.createElement("div",{className:se.group},o.exports.createElement("div",{style:{display:"flex",alignItems:"center"}},o.exports.createElement(ne,{name:e,type:i,toggle:O,qty:d.length,isOpen:l}),o.exports.createElement(x,{title:"Test latency",kind:"minimal",onClick:ke,isLoading:F},o.exports.createElement(Ft,null))),Lt(l?ue:pe,{all:d,now:c,isSelectable:v,itemOnTapCallback:D}))}const It=_((e,{name:t,delay:r})=>{const n=Z(e),s=Y(e),a=z(e),i=B(e),c=n[t],{all:l,type:u,now:p}=c;return{all:l,delay:r,hideUnavailableProxies:i,proxySortBy:a,proxies:n,type:u,now:p,isOpen:s[`proxyGroup:${t}`]}})($t),{useCallback:de,useState:zt}=m;function Bt({dispatch:e,apiConfig:t,name:r}){return de(()=>e(Ne(t,r)),[t,e,r])}function qt({dispatch:e,apiConfig:t,names:r}){const[n,s]=zt(!1);return[de(async()=>{if(!n){s(!0);try{await e(De(t,r))}catch{}s(!1)}},[t,e,r,n]),n]}const{useState:jt,useCallback:Ht}=m;function Wt({isLoading:e}){return e?o.exports.createElement(Ue,null,o.exports.createElement(k,{width:16,height:16})):o.exports.createElement(k,{width:16,height:16})}function Gt({dispatch:e,apiConfig:t}){const[r,n]=jt(!1);return[Ht(()=>{r||(n(!0),e(Fe(t)).then(()=>n(!1),()=>n(!1)))},[t,e,r]),r]}function Ut({dispatch:e,apiConfig:t,proxyProviders:r}){const{t:n}=$(),[s,a]=Gt({dispatch:e,apiConfig:t}),[i,c]=qt({apiConfig:t,dispatch:e,names:r.map(l=>l.name)});return o.exports.createElement(He,{icon:o.exports.createElement(Wt,{isLoading:a}),onClick:s,text:n("Test Latency"),style:We},r.length>0?o.exports.createElement(Ge,{text:n("update_all_proxy_provider"),onClick:i},o.exports.createElement(Ve,{isRotating:c})):null)}var fe=function(){if(typeof Map!="undefined")return Map;function e(t,r){var n=-1;return t.some(function(s,a){return s[0]===r?(n=a,!0):!1}),n}return function(){function t(){this.__entries__=[]}return Object.defineProperty(t.prototype,"size",{get:function(){return this.__entries__.length},enumerable:!0,configurable:!0}),t.prototype.get=function(r){var n=e(this.__entries__,r),s=this.__entries__[n];return s&&s[1]},t.prototype.set=function(r,n){var s=e(this.__entries__,r);~s?this.__entries__[s][1]=n:this.__entries__.push([r,n])},t.prototype.delete=function(r){var n=this.__entries__,s=e(n,r);~s&&n.splice(s,1)},t.prototype.has=function(r){return!!~e(this.__entries__,r)},t.prototype.clear=function(){this.__entries__.splice(0)},t.prototype.forEach=function(r,n){n===void 0&&(n=null);for(var s=0,a=this.__entries__;s<a.length;s++){var i=a[s];r.call(n,i[1],i[0])}},t}()}(),j=typeof window!="undefined"&&typeof document!="undefined"&&window.document===document,A=function(){return typeof global!="undefined"&&global.Math===Math?global:typeof self!="undefined"&&self.Math===Math?self:typeof window!="undefined"&&window.Math===Math?window:Function("return this")()}(),Vt=function(){return typeof requestAnimationFrame=="function"?requestAnimationFrame.bind(A):function(e){return setTimeout(function(){return e(Date.now())},1e3/60)}}(),Kt=2;function Zt(e,t){var r=!1,n=!1,s=0;function a(){r&&(r=!1,e()),n&&c()}function i(){Vt(a)}function c(){var l=Date.now();if(r){if(l-s<Kt)return;n=!0}else r=!0,n=!1,setTimeout(i,t);s=l}return c}var Yt=20,Jt=["top","right","bottom","left","width","height","size","weight"],Qt=typeof MutationObserver!="undefined",Xt=function(){function e(){this.connected_=!1,this.mutationEventsAdded_=!1,this.mutationsObserver_=null,this.observers_=[],this.onTransitionEnd_=this.onTransitionEnd_.bind(this),this.refresh=Zt(this.refresh.bind(this),Yt)}return e.prototype.addObserver=function(t){~this.observers_.indexOf(t)||this.observers_.push(t),this.connected_||this.connect_()},e.prototype.removeObserver=function(t){var r=this.observers_,n=r.indexOf(t);~n&&r.splice(n,1),!r.length&&this.connected_&&this.disconnect_()},e.prototype.refresh=function(){var t=this.updateObservers_();t&&this.refresh()},e.prototype.updateObservers_=function(){var t=this.observers_.filter(function(r){return r.gatherActive(),r.hasActive()});return t.forEach(function(r){return r.broadcastActive()}),t.length>0},e.prototype.connect_=function(){!j||this.connected_||(document.addEventListener("transitionend",this.onTransitionEnd_),window.addEventListener("resize",this.refresh),Qt?(this.mutationsObserver_=new MutationObserver(this.refresh),this.mutationsObserver_.observe(document,{attributes:!0,childList:!0,characterData:!0,subtree:!0})):(document.addEventListener("DOMSubtreeModified",this.refresh),this.mutationEventsAdded_=!0),this.connected_=!0)},e.prototype.disconnect_=function(){!j||!this.connected_||(document.removeEventListener("transitionend",this.onTransitionEnd_),window.removeEventListener("resize",this.refresh),this.mutationsObserver_&&this.mutationsObserver_.disconnect(),this.mutationEventsAdded_&&document.removeEventListener("DOMSubtreeModified",this.refresh),this.mutationsObserver_=null,this.mutationEventsAdded_=!1,this.connected_=!1)},e.prototype.onTransitionEnd_=function(t){var r=t.propertyName,n=r===void 0?"":r,s=Jt.some(function(a){return!!~n.indexOf(a)});s&&this.refresh()},e.getInstance=function(){return this.instance_||(this.instance_=new e),this.instance_},e.instance_=null,e}(),me=function(e,t){for(var r=0,n=Object.keys(t);r<n.length;r++){var s=n[r];Object.defineProperty(e,s,{value:t[s],enumerable:!1,writable:!1,configurable:!0})}return e},b=function(e){var t=e&&e.ownerDocument&&e.ownerDocument.defaultView;return t||A},he=M(0,0,0,0);function T(e){return parseFloat(e)||0}function ve(e){for(var t=[],r=1;r<arguments.length;r++)t[r-1]=arguments[r];return t.reduce(function(n,s){var a=e["border-"+s+"-width"];return n+T(a)},0)}function er(e){for(var t=["top","right","bottom","left"],r={},n=0,s=t;n<s.length;n++){var a=s[n],i=e["padding-"+a];r[a]=T(i)}return r}function tr(e){var t=e.getBBox();return M(0,0,t.width,t.height)}function rr(e){var t=e.clientWidth,r=e.clientHeight;if(!t&&!r)return he;var n=b(e).getComputedStyle(e),s=er(n),a=s.left+s.right,i=s.top+s.bottom,c=T(n.width),l=T(n.height);if(n.boxSizing==="border-box"&&(Math.round(c+a)!==t&&(c-=ve(n,"left","right")+a),Math.round(l+i)!==r&&(l-=ve(n,"top","bottom")+i)),!or(e)){var u=Math.round(c+a)-t,p=Math.round(l+i)-r;Math.abs(u)!==1&&(c-=u),Math.abs(p)!==1&&(l-=p)}return M(s.left,s.top,c,l)}var nr=function(){return typeof SVGGraphicsElement!="undefined"?function(e){return e instanceof b(e).SVGGraphicsElement}:function(e){return e instanceof b(e).SVGElement&&typeof e.getBBox=="function"}}();function or(e){return e===b(e).document.documentElement}function sr(e){return j?nr(e)?tr(e):rr(e):he}function ar(e){var t=e.x,r=e.y,n=e.width,s=e.height,a=typeof DOMRectReadOnly!="undefined"?DOMRectReadOnly:Object,i=Object.create(a.prototype);return me(i,{x:t,y:r,width:n,height:s,top:r,right:t+n,bottom:s+r,left:t}),i}function M(e,t,r,n){return{x:e,y:t,width:r,height:n}}var ir=function(){function e(t){this.broadcastWidth=0,this.broadcastHeight=0,this.contentRect_=M(0,0,0,0),this.target=t}return e.prototype.isActive=function(){var t=sr(this.target);return this.contentRect_=t,t.width!==this.broadcastWidth||t.height!==this.broadcastHeight},e.prototype.broadcastRect=function(){var t=this.contentRect_;return this.broadcastWidth=t.width,this.broadcastHeight=t.height,t},e}(),cr=function(){function e(t,r){var n=ar(r);me(this,{target:t,contentRect:n})}return e}(),lr=function(){function e(t,r,n){if(this.activeObservations_=[],this.observations_=new fe,typeof t!="function")throw new TypeError("The callback provided as parameter 1 is not a function.");this.callback_=t,this.controller_=r,this.callbackCtx_=n}return e.prototype.observe=function(t){if(!arguments.length)throw new TypeError("1 argument required, but only 0 present.");if(!(typeof Element=="undefined"||!(Element instanceof Object))){if(!(t instanceof b(t).Element))throw new TypeError('parameter 1 is not of type "Element".');var r=this.observations_;r.has(t)||(r.set(t,new ir(t)),this.controller_.addObserver(this),this.controller_.refresh())}},e.prototype.unobserve=function(t){if(!arguments.length)throw new TypeError("1 argument required, but only 0 present.");if(!(typeof Element=="undefined"||!(Element instanceof Object))){if(!(t instanceof b(t).Element))throw new TypeError('parameter 1 is not of type "Element".');var r=this.observations_;!r.has(t)||(r.delete(t),r.size||this.controller_.removeObserver(this))}},e.prototype.disconnect=function(){this.clearActive(),this.observations_.clear(),this.controller_.removeObserver(this)},e.prototype.gatherActive=function(){var t=this;this.clearActive(),this.observations_.forEach(function(r){r.isActive()&&t.activeObservations_.push(r)})},e.prototype.broadcastActive=function(){if(!!this.hasActive()){var t=this.callbackCtx_,r=this.activeObservations_.map(function(n){return new cr(n.target,n.broadcastRect())});this.callback_.call(t,r,t),this.clearActive()}},e.prototype.clearActive=function(){this.activeObservations_.splice(0)},e.prototype.hasActive=function(){return this.activeObservations_.length>0},e}(),ye=typeof WeakMap!="undefined"?new WeakMap:new fe,xe=function(){function e(t){if(!(this instanceof e))throw new TypeError("Cannot call a class as a function.");if(!arguments.length)throw new TypeError("1 argument required, but only 0 present.");var r=Xt.getInstance(),n=new lr(t,r,this);ye.set(this,n)}return e}();["observe","unobserve","disconnect"].forEach(function(e){xe.prototype[e]=function(){var t;return(t=ye.get(this))[e].apply(t,arguments)}});var ur=function(){return typeof A.ResizeObserver!="undefined"?A.ResizeObserver:xe}();const{memo:pr,useState:dr,useRef:_e,useEffect:be}=P;function fr(e){const t=_e();return be(()=>void(t.current=e),[e]),t.current}function mr(){const e=_e(),[t,r]=dr({height:0});return be(()=>{const n=new ur(([s])=>r(s.contentRect));return e.current&&n.observe(e.current),()=>n.disconnect()},[]),[e,t]}const hr={initialOpen:{height:"auto",transition:{duration:0}},open:e=>({height:e,opacity:1,visibility:"visible",transition:{duration:.3}}),closed:{height:0,opacity:0,visibility:"hidden",transition:{duration:.3}}},vr={open:{x:0},closed:{x:20}},Ee=pr(({children:e,isOpen:t})=>{const n=J.read().motion,s=fr(t),[a,{height:i}]=mr();return P.createElement("div",null,P.createElement(n.div,{animate:t&&s===t?"initialOpen":t?"open":"closed",custom:i,variants:hr},P.createElement(n.div,{variants:vr,ref:a},e)))}),yr="_updatedAt_1ql33_1",xr="_body_1ql33_8",_r="_actionFooter_1ql33_17",br="_refresh_1ql33_27";var L={updatedAt:yr,body:xr,actionFooter:_r,refresh:br};const{useState:Er,useCallback:ge}=m;function gr({name:e,proxies:t,delay:r,hideUnavailableProxies:n,proxySortBy:s,vehicleType:a,updatedAt:i,isOpen:c,dispatch:l,apiConfig:u}){const p=oe(t,r,n,s),[d,v]=Er(!1),y=Bt({dispatch:l,apiConfig:u,name:e}),f=ge(async()=>{v(!0),await l($e(u,e)),v(!1)},[u,l,e,v]),{app:{updateCollapsibleIsOpen:O}}=S(),D=ge(()=>{O("proxyProvider",e,!c)},[c,O,e]),F=Ze(new Date(i),new Date);return o.exports.createElement("div",{className:L.body},o.exports.createElement(ne,{name:e,toggle:D,type:a,isOpen:c,qty:p.length}),o.exports.createElement("div",{className:L.updatedAt},o.exports.createElement("small",null,"Updated ",F," ago")),o.exports.createElement(Ee,{isOpen:c},o.exports.createElement(ue,{all:p}),o.exports.createElement("div",{className:L.actionFooter},o.exports.createElement(x,{text:"Update",start:o.exports.createElement(Or,null),onClick:y}),o.exports.createElement(x,{text:"Health Check",start:o.exports.createElement(k,{size:16}),onClick:f,isLoading:d}))),o.exports.createElement(Ee,{isOpen:!c},o.exports.createElement(pe,{all:p})))}const wr={rest:{scale:1},pressed:{scale:.95}},Cr={rest:{rotate:0},hover:{rotate:360,transition:{duration:.3}}};function Or(){const t=J.read().motion;return o.exports.createElement(t.div,{className:L.refresh,variants:wr,initial:"rest",whileHover:"hover",whileTap:"pressed"},o.exports.createElement(t.div,{className:"flexCenter",variants:Cr},o.exports.createElement(Re,{size:16})))}const kr=(e,{proxies:t,name:r})=>{const n=B(e),s=I(e),a=Y(e),i=Q(e),c=z(e);return{apiConfig:i,proxies:t,delay:s,hideUnavailableProxies:n,proxySortBy:c,isOpen:a[`proxyProvider:${r}`]}},Pr=_(kr)(gr);function Sr({items:e}){return e.length===0?null:o.exports.createElement(o.exports.Fragment,null,o.exports.createElement(X,{title:"Proxy Provider"}),o.exports.createElement("div",null,e.map(t=>o.exports.createElement(Pr,{key:t.name,name:t.name,proxies:t.proxies,type:t.type,vehicleType:t.vehicleType,updatedAt:t.updatedAt}))))}const Rr="_labeledInput_cmki0_1";var H={labeledInput:Rr};const Ar=[["Natural","order_natural"],["LatencyAsc","order_latency_asc"],["LatencyDesc","order_latency_desc"],["NameAsc","order_name_asc"],["NameDesc","order_name_desc"]],{useCallback:we}=m;function Tr({appConfig:e}){const{app:{updateAppConfig:t}}=S(),r=we(a=>{t("proxySortBy",a.target.value)},[t]),n=we(a=>{t("hideUnavailableProxies",a)},[t]),{t:s}=$();return o.exports.createElement(o.exports.Fragment,null,o.exports.createElement("div",{className:H.labeledInput},o.exports.createElement("span",null,s("sort_in_grp")),o.exports.createElement("div",null,o.exports.createElement(Ye,{options:Ar.map(a=>[a[0],s(a[1])]),selected:e.proxySortBy,onChange:r}))),o.exports.createElement("hr",null),o.exports.createElement("div",{className:H.labeledInput},o.exports.createElement("span",null,s("hide_unavail_proxies")),o.exports.createElement("div",null,o.exports.createElement(ee,{name:"hideUnavailableProxies",checked:e.hideUnavailableProxies,onChange:n}))),o.exports.createElement("div",{className:H.labeledInput},o.exports.createElement("span",null,s("auto_close_conns")),o.exports.createElement("div",null,o.exports.createElement(ee,{name:"autoCloseOldConns",checked:e.autoCloseOldConns,onChange:a=>t("autoCloseOldConns",a)}))))}const Mr=e=>{const t=z(e),r=B(e),n=Ie(e);return{appConfig:{proxySortBy:t,hideUnavailableProxies:r,autoCloseOldConns:n}}};var Lr=_(Mr)(Tr);const Nr="_overlay_uuk3b_1",Dr="_cnt_uuk3b_5",Fr="_afterOpen_uuk3b_16";var W={overlay:Nr,cnt:Dr,afterOpen:Fr};const{useMemo:$r}=m;function Ce({isOpen:e,onRequestClose:t,children:r}){const n=$r(()=>({base:E(te.content,W.cnt),afterOpen:W.afterOpen,beforeClose:""}),[]);return o.exports.createElement(Ae,{isOpen:e,onRequestClose:t,className:n,overlayClassName:E(te.overlay,W.overlay)},r)}function Ir({color:e="currentColor",size:t=24}){return o.exports.createElement("svg",{fill:"none",xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 24 24",width:t,height:t,stroke:e,strokeWidth:"2",strokeLinecap:"round",strokeLinejoin:"round"},o.exports.createElement("path",{d:"M2 6h9M18.5 6H22"}),o.exports.createElement("circle",{cx:"16",cy:"6",r:"2"}),o.exports.createElement("path",{d:"M22 18h-9M6 18H2"}),o.exports.createElement("circle",{r:"2",transform:"matrix(-1 0 0 1 8 18)"}))}const zr="_topBar_jgy4z_1",Br="_topBarRight_jgy4z_13",qr="_textFilterContainer_jgy4z_22",jr="_group_jgy4z_29";var N={topBar:zr,topBarRight:Br,textFilterContainer:qr,group:jr};const{useState:Hr,useEffect:Wr,useCallback:Oe,useRef:Gr}=m;function Ur({dispatch:e,groupNames:t,delay:r,proxyProviders:n,apiConfig:s,showModalClosePrevConns:a}){const i=Gr({}),c=Oe(()=>{i.current.startAt=Date.now(),e(ze(s)).then(()=>{i.current.completeAt=Date.now()})},[s,e]);Wr(()=>{c();const f=()=>{i.current.startAt&&Date.now()-i.current.startAt>3e4&&c()};return window.addEventListener("focus",f,!1),()=>window.removeEventListener("focus",f,!1)},[c]);const[l,u]=Hr(!1),p=Oe(()=>{u(!1)},[]),{proxies:{closeModalClosePrevConns:d,closePrevConnsAndTheModal:v}}=S(),{t:y}=$();return o.exports.createElement(o.exports.Fragment,null,o.exports.createElement(Ce,{isOpen:l,onRequestClose:p},o.exports.createElement(Lr,null)),o.exports.createElement("div",{className:N.topBar},o.exports.createElement(X,{title:y("Proxies")}),o.exports.createElement("div",{className:N.topBarRight},o.exports.createElement("div",{className:N.textFilterContainer},o.exports.createElement(Ke,{textAtom:V})),o.exports.createElement(Te,{label:y("settings")},o.exports.createElement(x,{kind:"minimal",onClick:()=>u(!0)},o.exports.createElement(Ir,{size:16}))))),o.exports.createElement("div",null,t.map(f=>o.exports.createElement("div",{className:N.group,key:f},o.exports.createElement(It,{name:f,delay:r,apiConfig:s,dispatch:e})))),o.exports.createElement(Sr,{items:n}),o.exports.createElement("div",{style:{height:60}}),o.exports.createElement(Ut,{dispatch:e,apiConfig:s,proxyProviders:n}),o.exports.createElement(Ce,{isOpen:a,onRequestClose:d},o.exports.createElement(tt,{onClickPrimaryButton:()=>v(s),onClickSecondaryButton:d})))}const Vr=e=>({apiConfig:Q(e),groupNames:Be(e),proxyProviders:qe(e),delay:I(e),showModalClosePrevConns:je(e)});var tn=_(Vr)(Ur);export{tn as default};
