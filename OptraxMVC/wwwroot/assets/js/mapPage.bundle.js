/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./wwwroot/js/location/locationTree.js":
/*!*********************************************!*\
  !*** ./wwwroot/js/location/locationTree.js ***!
  \*********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   initializeTree: () => (/* binding */ initializeTree)
/* harmony export */ });
/* harmony import */ var _locationUtil_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./locationUtil.js */ "./wwwroot/js/location/locationUtil.js");

function initializeTree() {
  $('#locationTree').jstree({
    'core': {
      'data': {
        'url': './Locations/GetLocationTreeData',
        'dataType': 'json'
      }
    },
    'types': {
      'site': {
        'icon': 'fa-regular fa-font-awesome'
      },
      'field': {
        'icon': 'fas fa-tractor'
      },
      'row': {
        'icon': 'bi bi-layout-split'
      },
      'bed': {
        'icon': 'bi bi-grid-3x2-gap'
      },
      'plot': {
        'icon': 'bi bi-grip-horizontal'
      },
      'greenhouse': {
        'icon': 'fas fa-tractor'
      },
      'building': {
        'icon': 'fas fa-building'
      },
      'room': {
        'icon': 'bi bi-door-open'
      }
    },
    'plugins': ['types']
  });
  $('#locationTree').on("select_node.jstree", function (e, data) {
    var props = {
      action: 'GetDetails',
      data: {
        id: data.node.id
      }
    };
    (0,_locationUtil_js__WEBPACK_IMPORTED_MODULE_0__.loadPartial)(props);
  });
}
function addNode(data) {
  console.log('addSiteNode');
  $('#locationTree').jstree().create_node(data.parent, {
    id: data.id,
    text: data.text,
    type: data.type,
    children: false
  }, 'last');
}

/***/ }),

/***/ "./wwwroot/js/location/locationUtil.js":
/*!*********************************************!*\
  !*** ./wwwroot/js/location/locationUtil.js ***!
  \*********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   loadPartial: () => (/* binding */ loadPartial)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }

function loadPartial(_x) {
  return _loadPartial.apply(this, arguments);
}
function _loadPartial() {
  _loadPartial = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(props) {
    var response, view;
    return _regeneratorRuntime().wrap(function _callee$(_context) {
      while (1) switch (_context.prev = _context.next) {
        case 0:
          _context.next = 2;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__["default"].get("".concat(urlBase).concat(props.action, "/"), props.data);
        case 2:
          response = _context.sent;
          console.log('locjs loadPartial response', response);
          if (!(!response.success == true)) {
            _context.next = 7;
            break;
          }
          window.showMesage({
            msg: 'Error loading location',
            msgdiv: $('.loc-msg'),
            css: 'error'
          });
          throw new Error("HTTP Error: ".concat(response.status, " ").concat(response.statusText));
        case 7:
          _context.next = 9;
          return response.data;
        case 9:
          view = _context.sent;
          $("#loc-partial").html(view);
          locFormUtil.setFormListeners();
        case 12:
        case "end":
          return _context.stop();
      }
    }, _callee);
  }));
  return _loadPartial.apply(this, arguments);
}

/***/ }),

/***/ "./wwwroot/js/map/layerManager.js":
/*!****************************************!*\
  !*** ./wwwroot/js/map/layerManager.js ***!
  \****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   getAllLayers: () => (/* binding */ getAllLayers),
/* harmony export */   getCirclesLayer: () => (/* binding */ getCirclesLayer),
/* harmony export */   getLayerset: () => (/* binding */ getLayerset),
/* harmony export */   getLinesLayer: () => (/* binding */ getLinesLayer),
/* harmony export */   getPointsLayer: () => (/* binding */ getPointsLayer),
/* harmony export */   getPolysLayer: () => (/* binding */ getPolysLayer),
/* harmony export */   initializeLayers: () => (/* binding */ initializeLayers),
/* harmony export */   loadFeatures: () => (/* binding */ loadFeatures),
/* harmony export */   loadObjects: () => (/* binding */ loadObjects),
/* harmony export */   setActions: () => (/* binding */ setActions),
/* harmony export */   setStyle: () => (/* binding */ setStyle),
/* harmony export */   setType: () => (/* binding */ setType)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
/* harmony import */ var _objectManager_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./objectManager.js */ "./wwwroot/js/map/objectManager.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var pointsL, linesL, polysL, circlesL;
var map = null;
function initializeLayers() {
  map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.getMap)();
  console.log('initializeLayers map: ', map);
  var satellite = L.tileLayer('https://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
    maxZoom: 20,
    subdomains: ['mt0', 'mt1', 'mt2', 'mt3'],
    attribution: '© Google'
  }).addTo(map);
  var osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
  });
  var baseMaps = {
    "Satellite": satellite,
    "OpenStreetMap": osm
  };
  L.control.layers(baseMaps).addTo(map);
  pointsL = L.geoJSON(null, {
    pointToLayer: function pointToLayer(feat, latlng) {
      var icon = (0,_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.createIcon)(feat.properties.iconPath);
      var l = L.marker(latlng, {
        icon: icon
      });
      setType(feat, 'Point');
      setActions(feat.properties, l);
      return l;
    }
  }).addTo(map);
  linesL = L.geoJSON(null, {
    style: function style(feat) {
      return setStyle(feat.properties);
    },
    onEachFeature: function onEachFeature(feat, l) {
      setType(feat, 'Line');
      setActions(feat.properties, l);
    }
  }).addTo(map);
  circlesL = L.geoJSON(null, {
    pointToLayer: function pointToLayer(feat, latlng) {
      var props = feat.properties;
      props["fillOpacity"] = 1;
      if (props && props.radius) {
        return L.circle(latlng, props);
      }
      return L.marker(latlng);
    },
    onEachFeature: function onEachFeature(feat, l) {
      setType(feat, 'Circle');
      setActions(feat.properties, l);
    }
  }).addTo(map);
  polysL = L.geoJSON(null, {
    style: function style(feat) {
      feat.properties["fillOpacity"] = 1;
      return setStyle(feat.properties);
    },
    onEachFeature: function onEachFeature(feat, l) {
      setType(feat, 'Polygon');
      setActions(feat.properties, l);
    }
  }).addTo(map);
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.setMap)(map);
}
function setType(feat, type) {
  feat.properties["objType"] = type;
}
function setStyle(props) {
  var style = {
    color: props.color,
    weight: props.weight,
    dashArray: props.dashArray,
    fillColor: props.fillColor,
    fillOpacity: props.fillOpacity
  };
  if (props.objType === 'Circle') {
    style["radius"] = props.radius;
  }
  return style;
}
function setActions(props, layer) {
  var type = props.objType;
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.setIndex)(props.id, layer);
  layer.bindTooltip(props.name, {
    permanent: true,
    direction: "top"
  });
  layer.on('click', /*#__PURE__*/function () {
    var _ref = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(e) {
      var center;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.setActive)(layer);
            center = type === 'Point' || type === 'Circle' ? e.latlng : layer.getBounds().getCenter();
            (0,_objectManager_js__WEBPACK_IMPORTED_MODULE_1__.loadEdit)(props.id, type, center);
          case 3:
          case "end":
            return _context.stop();
        }
      }, _callee);
    }));
    return function (_x) {
      return _ref.apply(this, arguments);
    };
  }());
  layer.on('remove', function () {
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.deleteIndex)(props.id);
    var map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_3__.getMap)();
    map.closePopup();
  });
}
function loadFeatures() {
  return _loadFeatures.apply(this, arguments);
}
function _loadFeatures() {
  _loadFeatures = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2() {
    return _regeneratorRuntime().wrap(function _callee2$(_context2) {
      while (1) switch (_context2.prev = _context2.next) {
        case 0:
          _context2.next = 2;
          return loadObjects(pointsL, 'Point');
        case 2:
          _context2.next = 4;
          return loadObjects(linesL, 'Line');
        case 4:
          _context2.next = 6;
          return loadObjects(polysL, 'Polygon');
        case 6:
          _context2.next = 8;
          return loadObjects(circlesL, 'Circle');
        case 8:
        case "end":
          return _context2.stop();
      }
    }, _callee2);
  }));
  return _loadFeatures.apply(this, arguments);
}
function loadObjects(_x2, _x3) {
  return _loadObjects.apply(this, arguments);
}
function _loadObjects() {
  _loadObjects = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee3(mapLayer, layerType) {
    var response;
    return _regeneratorRuntime().wrap(function _callee3$(_context3) {
      while (1) switch (_context3.prev = _context3.next) {
        case 0:
          _context3.prev = 0;
          console.log('mapLayer', mapLayer, 'layerType', layerType);
          _context3.next = 4;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__["default"].get('/Grow/Map/GetObjects', {
            objType: layerType
          });
        case 4:
          response = _context3.sent;
          console.log('response', response);
          if (!(response.success === false)) {
            _context3.next = 9;
            break;
          }
          alert("Failed to load ".concat(layerType.toLowerCase(), "s"));
          throw new Error(response.error || "Failed to load ".concat(layerType.toLowerCase(), "s"));
        case 9:
          mapLayer.addData(response.data);
          _context3.next = 15;
          break;
        case 12:
          _context3.prev = 12;
          _context3.t0 = _context3["catch"](0);
          console.error("Error loading points:", _context3.t0);
        case 15:
        case "end":
          return _context3.stop();
      }
    }, _callee3, null, [[0, 12]]);
  }));
  return _loadObjects.apply(this, arguments);
}
var getLayerset = function getLayerset(objType) {
  switch (objType) {
    case 'marker':
      return pointsL;
    case 'polyline':
      return linesL;
    case 'circle':
      return circlesL;
    default:
      return polysL;
  }
};
function getPointsLayer() {
  return pointsL;
}
function getLinesLayer() {
  return linesL;
}
function getCirclesLayer() {
  return circlesL;
}
function getPolysLayer() {
  return polysL;
}
function getAllLayers() {
  return [pointsL, linesL, circlesL, polysL];
}

/***/ }),

/***/ "./wwwroot/js/map/mapState.js":
/*!************************************!*\
  !*** ./wwwroot/js/map/mapState.js ***!
  \************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   deleteActive: () => (/* binding */ deleteActive),
/* harmony export */   deleteIndex: () => (/* binding */ deleteIndex),
/* harmony export */   getActive: () => (/* binding */ getActive),
/* harmony export */   getIndex: () => (/* binding */ getIndex),
/* harmony export */   getMap: () => (/* binding */ getMap),
/* harmony export */   hasIndex: () => (/* binding */ hasIndex),
/* harmony export */   onMapReady: () => (/* binding */ onMapReady),
/* harmony export */   setActive: () => (/* binding */ setActive),
/* harmony export */   setIndex: () => (/* binding */ setIndex),
/* harmony export */   setMap: () => (/* binding */ setMap)
/* harmony export */ });
function _createForOfIteratorHelper(r, e) { var t = "undefined" != typeof Symbol && r[Symbol.iterator] || r["@@iterator"]; if (!t) { if (Array.isArray(r) || (t = _unsupportedIterableToArray(r)) || e && r && "number" == typeof r.length) { t && (r = t); var _n = 0, F = function F() {}; return { s: F, n: function n() { return _n >= r.length ? { done: !0 } : { done: !1, value: r[_n++] }; }, e: function e(r) { throw r; }, f: F }; } throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); } var o, a = !0, u = !1; return { s: function s() { t = t.call(r); }, n: function n() { var r = t.next(); return a = r.done, r; }, e: function e(r) { u = !0, o = r; }, f: function f() { try { a || null == t["return"] || t["return"](); } finally { if (u) throw o; } } }; }
function _unsupportedIterableToArray(r, a) { if (r) { if ("string" == typeof r) return _arrayLikeToArray(r, a); var t = {}.toString.call(r).slice(8, -1); return "Object" === t && r.constructor && (t = r.constructor.name), "Map" === t || "Set" === t ? Array.from(r) : "Arguments" === t || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(t) ? _arrayLikeToArray(r, a) : void 0; } }
function _arrayLikeToArray(r, a) { (null == a || a > r.length) && (a = r.length); for (var e = 0, n = Array(a); e < a; e++) n[e] = r[e]; return n; }
var map = null;
var activeL = null;
var subscribers = [];
var layerIndex = new Map();
function setMap(newMap) {
  map = newMap;
  notifySubscribers();
}
function getMap() {
  return map;
}
function onMapReady(callback) {
  if (map !== null) {
    callback(map);
  } else {
    subscribers.push(callback);
  }
}
function notifySubscribers() {
  var _iterator = _createForOfIteratorHelper(subscribers),
    _step;
  try {
    for (_iterator.s(); !(_step = _iterator.n()).done;) {
      var cb = _step.value;
      cb(map);
    }
  } catch (err) {
    _iterator.e(err);
  } finally {
    _iterator.f();
  }
  subscribers.length = 0;
}
function setActive(layer) {
  activeL = layer;
}
function getActive() {
  return activeL;
}
function deleteActive() {
  activeL.remove();
}
function setIndex(id, layer) {
  layerIndex.set(id, layer);
}
function getIndex(id) {
  return layerIndex.get(id);
}
function deleteIndex(id) {
  layerIndex["delete"](id);
}
function hasIndex(id) {
  return layerIndex.has(id);
}

/***/ }),

/***/ "./wwwroot/js/map/objStyleUtil.js":
/*!****************************************!*\
  !*** ./wwwroot/js/map/objStyleUtil.js ***!
  \****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   createIcon: () => (/* binding */ createIcon),
/* harmony export */   restoreStyle: () => (/* binding */ restoreStyle),
/* harmony export */   saveStyle: () => (/* binding */ saveStyle),
/* harmony export */   selectIcon: () => (/* binding */ selectIcon),
/* harmony export */   selectIconColl: () => (/* binding */ selectIconColl),
/* harmony export */   setColorPicker: () => (/* binding */ setColorPicker),
/* harmony export */   setStyleListeners: () => (/* binding */ setStyleListeners),
/* harmony export */   updateIcon: () => (/* binding */ updateIcon),
/* harmony export */   updateStyle: () => (/* binding */ updateStyle)
/* harmony export */ });
/* harmony import */ var _utilities_color_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../utilities/color.js */ "./wwwroot/js/utilities/color.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function ownKeys(e, r) { var t = Object.keys(e); if (Object.getOwnPropertySymbols) { var o = Object.getOwnPropertySymbols(e); r && (o = o.filter(function (r) { return Object.getOwnPropertyDescriptor(e, r).enumerable; })), t.push.apply(t, o); } return t; }
function _objectSpread(e) { for (var r = 1; r < arguments.length; r++) { var t = null != arguments[r] ? arguments[r] : {}; r % 2 ? ownKeys(Object(t), !0).forEach(function (r) { _defineProperty(e, r, t[r]); }) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(t)) : ownKeys(Object(t)).forEach(function (r) { Object.defineProperty(e, r, Object.getOwnPropertyDescriptor(t, r)); }); } return e; }
function _defineProperty(e, r, t) { return (r = _toPropertyKey(r)) in e ? Object.defineProperty(e, r, { value: t, enumerable: !0, configurable: !0, writable: !0 }) : e[r] = t, e; }
function _toPropertyKey(t) { var i = _toPrimitive(t, "string"); return "symbol" == _typeof(i) ? i : i + ""; }
function _toPrimitive(t, r) { if ("object" != _typeof(t) || !t) return t; var e = t[Symbol.toPrimitive]; if (void 0 !== e) { var i = e.call(t, r || "default"); if ("object" != _typeof(i)) return i; throw new TypeError("@@toPrimitive must return a primitive value."); } return ("string" === r ? String : Number)(t); }


var formID = '#mapObjForm';
function createIcon(url) {
  return L.icon({
    iconUrl: url,
    iconSize: [32, 32],
    iconAnchor: [16, 32],
    popupAnchor: [0, -32],
    tooltipAnchor: [0, -32]
  });
}
function updateIcon(props) {
  if (props.iconURL && props.iconURL.length > 0) {
    var newIcon = createIcon(props.iconURL);
    props.marker.setIcon(newIcon);
  }
  var tooltipContent = props.title != undefined ? props.title : "";
  props.marker._tooltip.setContent(tooltipContent);
}
function selectIcon($icon) {
  $('.icon-div').removeClass('selected');
  $('#IconID').val($icon.data('iconid')).change();
  $icon.addClass('selected');
  var imgURL = $icon.find('img').attr('src');
  var props = {
    iconURL: imgURL,
    marker: (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getActive)(),
    title: $(formID + ' #Name').val(),
    desc: $(formID + ' #Notes').val()
  };
  updateIcon(props);
}
function selectIconColl($coll) {
  var collID = $coll.data('collid');
  $('.icon-coll-name').removeClass('selected');
  $(".coll-name-".concat(collID)).addClass('selected');
  $('.preview-div').addClass('d-none');
  $(".preview-div.preview-coll-".concat(collID)).removeClass('d-none');
}
function setColorPicker(attr) {
  return {
    type: "component",
    showInput: true,
    showPalette: true,
    showButtons: false,
    preferredFormat: "rgb",
    togglePaletteOnly: true,
    showSelectionPalette: true,
    selectionPalette: [_utilities_color_js__WEBPACK_IMPORTED_MODULE_0__.colorSwatches],
    change: function change(color) {
      updateStyle(attr, color.toRgbString());
    },
    move: function move(color) {
      updateStyle(attr, color.toRgbString());
    },
    show: function show(color) {
      updateStyle(attr, color.toRgbString());
    }
  };
}
function updateStyle(input, val) {
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getActive)();
  console.log('updateStyle layer', layer, 'input', input, 'val', val);
  switch (input) {
    case 'name':
      layer._tooltip.setContent(val);
      break;
    case 'color':
      layer.setStyle({
        color: val
      });
      break;
    case 'fillColor':
      layer.setStyle({
        fillColor: val
      });
      break;
    case 'weight':
      layer.setStyle({
        weight: val
      });
      break;
    case 'dashArray':
      layer.setStyle({
        dashArray: val
      });
      break;
    default:
      break;
  }
}
function saveStyle() {
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getActive)();
  var tooltip = layer.getTooltip();
  layer._origStyle = {
    icon: layer instanceof L.Marker ? layer.getIcon() : null,
    style: layer.setStyle ? _objectSpread({}, layer.options) : null,
    content: tooltip.getContent()
  };
}
function restoreStyle(input, val) {
  console.log('restoreStyle');
  var l = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getActive)();
  var origStyle = l._origStyle;
  var tooltip = l.getTooltip();
  if (l instanceof L.Marker && origStyle.icon) {
    l.setIcon(origStyle.icon);
    l._tooltip.setContent();
  } else if (l.setStyle && origStyle.style) {
    l.setStyle(origStyle.style);
  }
  if (tooltip) {
    tooltip.setContent(origStyle.content);
  }
  delete l._originalStyle;
}
function setStyleListeners(formID) {
  // Points
  $('.icon-coll-name').on('click', function () {
    selectIconColl($(this)); // change icon collection display
  });
  $('.icon-div').on('click', function () {
    selectIcon($(this)); // Update point icon
  });
  $('.point-info').on('input', function () {
    var props = {
      marker: (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getActive)(),
      title: $('#Name').val()
    }; // Change point's tooltip content
    updateIcon(props);
  });

  // Not Points
  $(formID + ' #Pattern').on('change', function () {
    var pattern = $(this).val();
    if (pattern == 'solid') {
      $(formID + ' #DashArray').val(0).change();
      $(formID + ' #DashArray').attr('readonly', 'readonly');
    } else {
      $(formID + ' #DashArray').val('5 5').change();
      $(formID + ' #DashArray').removeAttr('readonly');
    }
    setTimeout(function () {
      updateStyle('dashArray', $(formID + ' #DashArray').val());
    }, 50);
  });
  $(formID + ' #Name').on('input', function () {
    updateStyle('name', $(this).val());
  });
  $(formID + ' #DashArray').on('input', function () {
    updateStyle('dashArray', $(this).val());
  });
  $(formID + ' #Weight').on('change', function () {
    updateStyle('weight', $(this).val());
  });
}

/***/ }),

/***/ "./wwwroot/js/map/objectManager.js":
/*!*****************************************!*\
  !*** ./wwwroot/js/map/objectManager.js ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   addObject: () => (/* binding */ addObject),
/* harmony export */   getLastLayer: () => (/* binding */ getLastLayer),
/* harmony export */   loadEdit: () => (/* binding */ loadEdit),
/* harmony export */   mapFormUtil: () => (/* binding */ mapFormUtil),
/* harmony export */   onDelete: () => (/* binding */ onDelete),
/* harmony export */   showEditPopup: () => (/* binding */ showEditPopup),
/* harmony export */   updateHiddenFields: () => (/* binding */ updateHiddenFields)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
/* harmony import */ var _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../utilities/form.js */ "./wwwroot/js/utilities/form.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function _toConsumableArray(r) { return _arrayWithoutHoles(r) || _iterableToArray(r) || _unsupportedIterableToArray(r) || _nonIterableSpread(); }
function _nonIterableSpread() { throw new TypeError("Invalid attempt to spread non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }
function _unsupportedIterableToArray(r, a) { if (r) { if ("string" == typeof r) return _arrayLikeToArray(r, a); var t = {}.toString.call(r).slice(8, -1); return "Object" === t && r.constructor && (t = r.constructor.name), "Map" === t || "Set" === t ? Array.from(r) : "Arguments" === t || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(t) ? _arrayLikeToArray(r, a) : void 0; } }
function _iterableToArray(r) { if ("undefined" != typeof Symbol && null != r[Symbol.iterator] || null != r["@@iterator"]) return Array.from(r); }
function _arrayWithoutHoles(r) { if (Array.isArray(r)) return _arrayLikeToArray(r); }
function _arrayLikeToArray(r, a) { (null == a || a > r.length) && (a = r.length); for (var e = 0, n = Array(a); e < a; e++) n[e] = r[e]; return n; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getMap)();
var urlBase = '/Grow/Map/';
var typeMap = {
  marker: 'Point',
  polyline: 'Line',
  circle: 'Circle'
};
var layerProps = {
  id: -1,
  weight: 3,
  dashArray: '5 5',
  color: '#1d52d7',
  fillColor: '#1d52d782',
  iconPath: 'https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE'
};

// Create
function addObject(_x, _x2) {
  return _addObject.apply(this, arguments);
}
function _addObject() {
  _addObject = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2(e, layerSet) {
    var _typeMap$e$layerType;
    var l, type, latlng, feature, geojson, props;
    return _regeneratorRuntime().wrap(function _callee2$(_context2) {
      while (1) switch (_context2.prev = _context2.next) {
        case 0:
          l = e.layer;
          type = (_typeMap$e$layerType = typeMap[e.layerType]) !== null && _typeMap$e$layerType !== void 0 ? _typeMap$e$layerType : 'Polygon';
          console.log('layerset', layerSet, 'layer', l, 'type', type);
          layerProps["name"] = 'New ' + type;
          if (type === 'Circle') {
            latlng = l.getLatLng();
            layerProps["radius"] = l.getRadius();
            layerProps['latlng'] = latlng;
            console.log('addObject circle props', layerProps);
            feature = {
              type: "Feature",
              properties: layerProps,
              geometry: {
                type: "Point",
                coordinates: [latlng.lng, latlng.lat]
              }
            };
            console.log('addObject feature', feature);
            layerSet.addData(feature);
          } else {
            geojson = l.toGeoJSON();
            geojson.properties = layerProps;
            layerSet.addData(geojson);
          }
          console.log('layer', l);
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.setActive)(getLastLayer(layerSet));
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.setIndex)(-1, (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getActive)());
          props = {
            id: -1,
            type: type,
            data: {
              objType: type
            },
            url: "".concat(urlBase, "AddNewObject/"),
            center: type == 'Point' || type == 'Circle' ? l.getLatLng() : l.getBounds().getCenter()
          };
          _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.saveStyle();
          _context2.next = 12;
          return showEditPopup(props).then(function () {
            mapFormUtil.setFormListeners('#mapObjForm');
            updateHiddenFields(type, layerProps);
            map.on('popupclose', _mapState_js__WEBPACK_IMPORTED_MODULE_2__.deleteActive);
          });
        case 12:
        case "end":
          return _context2.stop();
      }
    }, _callee2);
  }));
  return _addObject.apply(this, arguments);
}
var getLastLayer = function getLastLayer(layerSet) {
  var layers = layerSet.getLayers();
  return layers[layers.length - 1];
};
function showEditPopup(_x3) {
  return _showEditPopup.apply(this, arguments);
}
function _showEditPopup() {
  _showEditPopup = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee3(props) {
    var response, view, $editDiv;
    return _regeneratorRuntime().wrap(function _callee3$(_context3) {
      while (1) switch (_context3.prev = _context3.next) {
        case 0:
          map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getMap)();
          console.log('showEditPopup props', props, 'map', map);
          _context3.next = 4;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__["default"].get(props.url, props.data);
        case 4:
          response = _context3.sent;
          console.log('showEditPopup response', response);
          if (!(!response.success == true)) {
            _context3.next = 9;
            break;
          }
          window.showMesage({
            msg: 'Error loading' + props.type,
            msgdiv: $('.map-msg'),
            css: 'error'
          });
          throw new Error("HTTP Error: ".concat(response.status, " ").concat(response.statusText));
        case 9:
          $('.title-control').hide();
          _context3.next = 12;
          return response.data;
        case 12:
          view = _context3.sent;
          $editDiv = $('<div/>').addClass('mapObj-popup').html(view);
          L.DomEvent.disableClickPropagation($editDiv[0]);
          L.DomEvent.disableScrollPropagation($editDiv[0]);
          L.popup({
            offset: L.point(0, -30)
          }).setLatLng(props.center).setContent($editDiv[0]).openOn(map);
          $($editDiv).find('#Color.color-picker').spectrum(_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.setColorPicker('color'));
          $($editDiv).find('#FillColor.color-picker').spectrum(_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.setColorPicker('fillColor'));
        case 19:
        case "end":
          return _context3.stop();
      }
    }, _callee3);
  }));
  return _showEditPopup.apply(this, arguments);
}
function updateHiddenFields(type, props) {
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getActive)();
  var mapID = $("#mapForm").find("#ID").val();
  $('#MapID').val(mapID);
  if (type.toLowerCase() == 'point') {
    var latlng = layer.getLatLng();
    $('#Latitude').val(latlng.lat);
    $('#Longitude').val(latlng.lng);
  } else if (type.toLowerCase() == 'circle') {
    $('#Latitude').val(props.latlng.lat);
    $('#Longitude').val(props.latlng.lng);
    $('#Radius').val(props.radius);
  } else if (type.toLowerCase() === 'line') {
    var latlngs = layer.getLatLngs();
    var coordString = latlngs.map(function (p) {
      return "".concat(p.lng, " ").concat(p.lat);
    }).join(', ');
    var wkt = "LINESTRING(".concat(coordString, ")");
    $('#GeometryWKT').val(wkt);
  } else if (type.toLowerCase() == 'polygon') {
    var _latlngs$;
    var _latlngs = layer.getLatLngs();
    var or = (_latlngs$ = _latlngs[0]) !== null && _latlngs$ !== void 0 ? _latlngs$ : _latlngs; // outer ring
    var closed = _toConsumableArray(or);
    if (or.length > 0 && (or[0].lat !== or[or.length - 1].lat || or[0].lng !== or[or.length - 1].lng)) {
      closed.push(or[0]); // close the ring
    }
    var _coordString = closed.map(function (p) {
      return "".concat(p.lng, " ").concat(p.lat);
    }).join(', ');
    var _wkt = "POLYGON((".concat(_coordString, "))");
    $('#GeometryWKT').val(_wkt);
  }
}

// Edit
function loadEdit(_x4, _x5, _x6) {
  return _loadEdit.apply(this, arguments);
}

// Delete
function _loadEdit() {
  _loadEdit = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee4(id, type, center) {
    var props;
    return _regeneratorRuntime().wrap(function _callee4$(_context4) {
      while (1) switch (_context4.prev = _context4.next) {
        case 0:
          props = {
            type: type,
            center: center,
            data: {
              id: id,
              objType: type
            },
            url: "".concat(urlBase, "LoadEdit/")
          };
          _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.saveStyle();
          _context4.next = 4;
          return showEditPopup(props).then(function () {
            mapFormUtil.setFormListeners('#mapObjForm');
            map.on('popupclose', _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.restoreStyle);
          });
        case 4:
        case "end":
          return _context4.stop();
      }
    }, _callee4);
  }));
  return _loadEdit.apply(this, arguments);
}
function onDelete(_x7, _x8) {
  return _onDelete.apply(this, arguments);
}
function _onDelete() {
  _onDelete = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee5(id, type) {
    var response;
    return _regeneratorRuntime().wrap(function _callee5$(_context5) {
      while (1) switch (_context5.prev = _context5.next) {
        case 0:
          _context5.next = 2;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__["default"].postForm("".concat(urlBase, "DeleteObject/"), {
            id: id,
            objType: type
          });
        case 2:
          response = _context5.sent;
          console.log('onDelete response', response);
          if (response.success == true) {
            console.log('onDelete curLayer', (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getActive)());
            (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.deleteActive)();
          }
        case 5:
        case "end":
          return _context5.stop();
      }
    }, _callee5);
  }));
  return _onDelete.apply(this, arguments);
}
var mapFormUtil = {
  setFormListeners: function setFormListeners(formID) {
    console.log('mapFormUtil setFormListeners formID', formID);
    $(formID).on('submit', function (event) {
      event.preventDefault();
      mapFormUtil.onSubmitForm(formID); // submit form
    });
    $(document).off('click', formID + ' .btn-red').on('click', formID + ' .btn-red', function () {
      var id = $(formID).data('id');
      var type = $(formID).data('obj');
      onDelete(id, type);
    });
    _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__.formUtil.setListeners(formID);
    if (formID == '#mapObjForm') {
      _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.setStyleListeners('#mapObjForm');
    }
  },
  onSubmitForm: function () {
    var _onSubmitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(formID) {
      var $form, isCreate, response, newName, objType, action;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            $form = $(formID);
            console.log('mapUtil onSubmitForm $form', $form);
            isCreate = $form.attr('action').includes('Create');
            _context.next = 5;
            return _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__.formUtil.submitForm(formID);
          case 5:
            response = _context.sent;
            console.log('mapUtil onSubmitForm response', response);
            if (response && response.success) {
              if (formID == '#mapForm') {
                newName = $('#mapForm #Name').val();
                $('.map-info').toggleClass('d-none');
                $('.map-title').text(newName);
              } else {
                map.off('popupclose', _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.restoreStyle);
                map.off('popupclose', _mapState_js__WEBPACK_IMPORTED_MODULE_2__.deleteActive);
                map.closePopup();
                objType = $form.data('obj');
                action = isCreate ? 'Created' : 'Updated';
                if (isCreate && response.data) {
                  mapFormUtil.updateID(response.data, $form.data('obj'));
                }
                window.showMessage({
                  msg: "".concat(objType, " ").concat(action, "!"),
                  css: 'success',
                  msgdiv: $('.map-msg')
                });
              }
            } else {
              alert('Error! ' + response.error);
            }
          case 8:
          case "end":
            return _context.stop();
        }
      }, _callee);
    }));
    function onSubmitForm(_x9) {
      return _onSubmitForm.apply(this, arguments);
    }
    return onSubmitForm;
  }(),
  updateID: function updateID(data, type) {
    var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getActive)();
    var id = data.properties.id;
    layer.feature.properties.id = id;
    console.log('updateID layer', layer, 'id', id, 'data', data);
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.deleteIndex)(-1);
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_2__.setIndex)(id, layer);
  }
};

/***/ }),

/***/ "./wwwroot/js/utilities/api.js":
/*!*************************************!*\
  !*** ./wwwroot/js/utilities/api.js ***!
  \*************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": () => (__WEBPACK_DEFAULT_EXPORT__)
/* harmony export */ });
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }
var apiService = {
  request: function () {
    var _request = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(_ref) {
      var url, _ref$method, method, _ref$data, data, _ref$contentType, contentType, _ref$timeout, timeout, controller, id, options, query, _result$data, _result$success, _result$data$success, response, responseType, result, _data, success, error;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            url = _ref.url, _ref$method = _ref.method, method = _ref$method === void 0 ? "GET" : _ref$method, _ref$data = _ref.data, data = _ref$data === void 0 ? null : _ref$data, _ref$contentType = _ref.contentType, contentType = _ref$contentType === void 0 ? "json" : _ref$contentType, _ref$timeout = _ref.timeout, timeout = _ref$timeout === void 0 ? 30000 : _ref$timeout;
            controller = new AbortController();
            id = setTimeout(function () {
              return controller.abort();
            }, timeout);
            options = {
              method: method,
              headers: {},
              signal: controller.signal
            };
            if (data) {
              if (method.toUpperCase() === "GET" || contentType === null) {
                query = new URLSearchParams(data).toString(); // Append query string
                url += (url.includes("?") ? "&" : "?") + query;
              } else if (contentType === "json") {
                options.body = JSON.stringify(data);
                options.headers["Content-Type"] = "application/json";
              } else if (contentType === "form") {
                options.headers["Content-Type"] = "application/x-www-form-urlencoded";
                options.body = typeof data === "string" ? data : new URLSearchParams(data).toString();
              }
            }
            _context.prev = 5;
            _context.next = 8;
            return fetch(url, options);
          case 8:
            response = _context.sent;
            clearTimeout(id);
            responseType = (response.headers.get("Content-Type") || "").toLowerCase();
            if (response.ok) {
              _context.next = 13;
              break;
            }
            return _context.abrupt("return", {
              success: false,
              status: response.status,
              error: "HTTP ".concat(response.status, ": ").concat(response.statusText)
            });
          case 13:
            if (!responseType.includes("application/json")) {
              _context.next = 19;
              break;
            }
            _context.next = 16;
            return response.json();
          case 16:
            _context.t0 = _context.sent;
            _context.next = 22;
            break;
          case 19:
            _context.next = 21;
            return response.text();
          case 21:
            _context.t0 = _context.sent;
          case 22:
            result = _context.t0;
            _data = (_result$data = result.data) !== null && _result$data !== void 0 ? _result$data : result;
            success = (_result$success = result.success) !== null && _result$success !== void 0 ? _result$success : result.data ? (_result$data$success = result.data.success) !== null && _result$data$success !== void 0 ? _result$data$success : true : true;
            error = success ? '' : result.msg;
            return _context.abrupt("return", {
              success: success,
              data: _data,
              error: error
            });
          case 29:
            _context.prev = 29;
            _context.t1 = _context["catch"](5);
            clearTimeout(id);
            return _context.abrupt("return", {
              success: false,
              error: _context.t1.name === "AbortError" ? "Request timed out" : _context.t1.message
            });
          case 33:
          case "end":
            return _context.stop();
        }
      }, _callee, null, [[5, 29]]);
    }));
    function request(_x) {
      return _request.apply(this, arguments);
    }
    return request;
  }(),
  get: function () {
    var _get = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2(url) {
      var params,
        _args2 = arguments;
      return _regeneratorRuntime().wrap(function _callee2$(_context2) {
        while (1) switch (_context2.prev = _context2.next) {
          case 0:
            params = _args2.length > 1 && _args2[1] !== undefined ? _args2[1] : null;
            _context2.next = 3;
            return this.request({
              url: url,
              method: "GET",
              data: params
            });
          case 3:
            return _context2.abrupt("return", _context2.sent);
          case 4:
          case "end":
            return _context2.stop();
        }
      }, _callee2, this);
    }));
    function get(_x2) {
      return _get.apply(this, arguments);
    }
    return get;
  }(),
  post: function () {
    var _post = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee3(url) {
      var data,
        _args3 = arguments;
      return _regeneratorRuntime().wrap(function _callee3$(_context3) {
        while (1) switch (_context3.prev = _context3.next) {
          case 0:
            data = _args3.length > 1 && _args3[1] !== undefined ? _args3[1] : null;
            _context3.next = 3;
            return this.request({
              url: url,
              method: "POST",
              data: data
            });
          case 3:
            return _context3.abrupt("return", _context3.sent);
          case 4:
          case "end":
            return _context3.stop();
        }
      }, _callee3, this);
    }));
    function post(_x3) {
      return _post.apply(this, arguments);
    }
    return post;
  }(),
  postJson: function () {
    var _postJson = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee4(url, data) {
      return _regeneratorRuntime().wrap(function _callee4$(_context4) {
        while (1) switch (_context4.prev = _context4.next) {
          case 0:
            _context4.next = 2;
            return this.request({
              url: url,
              method: "POST",
              data: data,
              contentType: "json"
            });
          case 2:
            return _context4.abrupt("return", _context4.sent);
          case 3:
          case "end":
            return _context4.stop();
        }
      }, _callee4, this);
    }));
    function postJson(_x4, _x5) {
      return _postJson.apply(this, arguments);
    }
    return postJson;
  }(),
  postForm: function () {
    var _postForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee5(url, data) {
      return _regeneratorRuntime().wrap(function _callee5$(_context5) {
        while (1) switch (_context5.prev = _context5.next) {
          case 0:
            console.log('api postForm url', url, 'data', data);
            _context5.next = 3;
            return this.request({
              url: url,
              method: "POST",
              data: data,
              contentType: "form"
            });
          case 3:
            return _context5.abrupt("return", _context5.sent);
          case 4:
          case "end":
            return _context5.stop();
        }
      }, _callee5, this);
    }));
    function postForm(_x6, _x7) {
      return _postForm.apply(this, arguments);
    }
    return postForm;
  }()
};
/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = (apiService);

/***/ }),

/***/ "./wwwroot/js/utilities/color.js":
/*!***************************************!*\
  !*** ./wwwroot/js/utilities/color.js ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   colorSwatches: () => (/* binding */ colorSwatches)
/* harmony export */ });
var colorSwatches = ['#FF3333', '#EF7A1A', '#F9C04D', '#328532', '#1D52D7', '#9E6DD9', '#DA6565', '#F9AA8A', '#F8DEA0', '#97CA91', '#9BB2E3', '#C4ADCA'];
var bwSwatches = ["#000000", "#FFFFFF"];
$(document).ready(function () {

  //$(document).on('click', '.color-picker', function () {
  //    Coloris({
  //        alpha: true,
  //        swatches: colorSwatches,
  //        onChange: (color) => $('.hex-prev').css('background-color', color)
  //    });
  //});

  //$(document).on('click', '.color-picker-bw', function () {
  //    Coloris({
  //        alpha: false,
  //        swatches: bwSwatches,
  //        onChange: (color) => $('.hex-prev').css('color', color)
  //    });
  //});
});

/***/ }),

/***/ "./wwwroot/js/utilities/form.js":
/*!**************************************!*\
  !*** ./wwwroot/js/utilities/form.js ***!
  \**************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   Changes: () => (/* binding */ Changes),
/* harmony export */   OrigModel: () => (/* binding */ OrigModel),
/* harmony export */   formUtil: () => (/* binding */ formUtil)
/* harmony export */ });
/* harmony import */ var _api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./api.js */ "./wwwroot/js/utilities/api.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }

var OrigModel;
var Changes = [];
var $form;
var formUtil = {
  setListeners: function setListeners(formID) {
    $form = $(document).find($(formID));
    if ($.validator && $.validator.unobtrusive) {
      $.validator.unobtrusive.parse($form);
    }
    console.log('setListeners form', $form, 'action', $form.attr('action'));
    if ($form.attr('action').includes('Edit')) {
      formUtil.setModelChanges();
    }
  },
  setModelChanges: function setModelChanges() {
    Changes = [];
    $('#changes').val(null);
    OrigModel = formUtil.arrayToModel($form.serializeArray());
    $('.attr').off('change').on('change', function () {
      var attrName = $(this).attr('Name');
      if ($(this).val() != OrigModel[attrName]) {
        Changes.push(attrName); // if updated value != original value, add attribute name to list of changes
      } else if (Changes.length > 0) {
        Changes = Changes.filter(function (c) {
          return c != attrName;
        }); // if new value == orig value, remove attr from changes if it's in there.
      }
      var changed = Changes.length > 0;
      $('#changes').val(changed > 0 ? Changes.toString() : null);
    });
  },
  submitForm: function () {
    var _submitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(formID) {
      var action, proceed;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            $form = $(formID);
            console.log('formUtil submitForm $form', $form);
            action = $form.attr('action');
            console.log('formUtil submitForm changes', Changes, 'action', action);

            /*        let proceed = action.includes('Create') || Changes.length > 0;*/
            proceed = true;
            console.log('formUtil submitForm', proceed);
            if (!($form.valid() && proceed)) {
              _context.next = 12;
              break;
            }
            _context.next = 9;
            return _api_js__WEBPACK_IMPORTED_MODULE_0__["default"].postForm(action, $form.serialize());
          case 9:
            return _context.abrupt("return", _context.sent);
          case 12:
            if (!(action.includes('Create') && !$form.valid())) {
              _context.next = 16;
              break;
            }
            return _context.abrupt("return", {
              success: false,
              error: 'Invalid form'
            });
          case 16:
            if (!(Changes.length == 0)) {
              _context.next = 18;
              break;
            }
            return _context.abrupt("return", {
              success: true
            });
          case 18:
          case "end":
            return _context.stop();
        }
      }, _callee);
    }));
    function submitForm(_x) {
      return _submitForm.apply(this, arguments);
    }
    return submitForm;
  }(),
  showHideBtns: function showHideBtns(formID) {
    $form = $(formID);
    $(formID + ' button.toggle-edit').off('click').on('click', function () {
      console.log('formjs showHideBtns click');
      $(formID + ' button.form-btn').toggleClass('d-none');
      $('.m-toggle').toggleClass('d-none');
    });
  },
  arrayToModel: function arrayToModel(arr) {
    var model = {};
    for (var i = 0; i < arr.length; i++) {
      model[arr[i]['name']] = arr[i]['value'];
    }
    return model;
  }
};

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// This entry needs to be wrapped in an IIFE because it needs to be isolated against other entry modules.
(() => {
var __webpack_exports__ = {};
/*!*****************************************!*\
  !*** ./wwwroot/js/location/location.js ***!
  \*****************************************/
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   locFormUtil: () => (/* binding */ locFormUtil)
/* harmony export */ });
/* harmony import */ var _locationUtil_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./locationUtil.js */ "./wwwroot/js/location/locationUtil.js");
/* harmony import */ var _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../utilities/form.js */ "./wwwroot/js/utilities/form.js");
/* harmony import */ var _map_mapState_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../map/mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _locationTree_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./locationTree.js */ "./wwwroot/js/location/locationTree.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var urlBase = '/Grow/Locations/';
var formID = '#locForm';
var map = null;
$(document).ready(function () {
  setResizer();
  setLocListeners();
  _locationTree_js__WEBPACK_IMPORTED_MODULE_3__.initializeTree();
  (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_2__.onMapReady)(function (loadedMap) {
    map = loadedMap;
    console.log('map loaded');
  });
});
function setLocListeners() {
  $('#add-new-loc').on('click', function () {
    var props = {
      action: 'LoadCreate',
      data: {
        type: 'Field'
      }
    };
    (0,_locationUtil_js__WEBPACK_IMPORTED_MODULE_0__.loadPartial)(props);
  });
  $('#locForm .toggle-edit').on('click', function () {
    var model = $(this).parent('.model');
    model.find('.m-toggle').toggleClass('d-none');
  });
  locFormUtil.setFormListeners(formID);
}
function setResizer() {
  console.log('setResizer map', map);
  var $resizer = $('#resizer');
  var col2 = document.getElementById('loc-details');
  var col3 = document.getElementById('loc-map');
  $resizer.on('mousedown', function (e) {
    map = (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_2__.getMap)();
    e.preventDefault();
    document.body.style.cursor = 'col-resize';
    col3.style.pointerEvents = 'none';
    var resize = function resize(e) {
      var newWidth = e.clientX - col2.getBoundingClientRect().left;
      $('#loc-details').css('width', newWidth + 'px');
      map.invalidateSize();
    };
    var _stopResize = function stopResize() {
      col3.style.pointerEvents = 'auto';
      document.body.style.cursor = 'default';
      map.invalidateSize();
      document.removeEventListener('mousemove', resize);
      document.removeEventListener('mouseup', _stopResize);
    };
    document.addEventListener('mousemove', resize);
    document.addEventListener('mouseup', _stopResize);
  });
}
var locFormUtil = {
  setFormListeners: function setFormListeners() {
    $(formID).off('submit').on('submit', function (e) {
      e.preventDefault();
      locFormUtil.onSubmitForm(); // submit form
    });
    $(formID + ' .btn-red').off('click').on('click', function () {
      var id = $(formID).data('id');
      var type = $(formID).data('type');
      onDelete(id, type);
    });
    _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__.formUtil.setListeners(formID);
    _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__.formUtil.showHideBtns(formID);
    locFormUtil.setListeners();
  },
  onSubmitForm: function () {
    var _onSubmitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee() {
      var action, locType, isCreate, response, nodeData, msgTxt;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            action = $(formID).attr('action');
            locType = $(formID + ' #LocationType').val();
            isCreate = action && action.includes('Create');
            console.log('loc onSubmitForm objType: ', locType, ' action:', action);
            _context.next = 6;
            return _utilities_form_js__WEBPACK_IMPORTED_MODULE_1__.formUtil.submitForm(formID);
          case 6:
            response = _context.sent;
            console.log('loc onSubmitForm response', response);
            if (response && response.success) {
              if (isCreate) {
                nodeData = response.data;
                $(formID + ' .m-toggle').toggleClass('d-none');
              }
              if (response.data) {
                addSiteNode(response.data);
              }
              msgTxt = isCreate ? 'Created' : 'Updated';
              window.showMessage({
                msg: "".concat(objType, " ").concat(msgTxt, "!"),
                css: 'success',
                msgdiv: $('.msg-div')
              });
            } else {
              alert('Error! ' + response.error);
            }
          case 9:
          case "end":
            return _context.stop();
        }
      }, _callee);
    }));
    function onSubmitForm() {
      return _onSubmitForm.apply(this, arguments);
    }
    return onSubmitForm;
  }(),
  setListeners: function setListeners() {
    $(formID + ' #Name').on('input', function () {
      $(formID + ' #Address_Name').val($(this).val()).change();
    });
  }
};
})();

// This entry needs to be wrapped in an IIFE because it needs to be isolated against other entry modules.
(() => {
/*!*******************************!*\
  !*** ./wwwroot/js/map/map.js ***!
  \*******************************/
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _objectManager_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./objectManager.js */ "./wwwroot/js/map/objectManager.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _layerManager_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./layerManager.js */ "./wwwroot/js/map/layerManager.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var map = null;
var layersets = [];
$(document).ready(function () {
  initializeMap();
  $(window).on('resize', function () {
    setMapHeight();
  });
});
function initializeMap() {
  return _initializeMap.apply(this, arguments);
}
function _initializeMap() {
  _initializeMap = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee() {
    return _regeneratorRuntime().wrap(function _callee$(_context) {
      while (1) switch (_context.prev = _context.next) {
        case 0:
          map = L.map('map', {
            center: [39.8283, -98.5795],
            zoom: 4
          });
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_1__.setMap)(map);
          map.on('click', function (e) {
            e.originalEvent.preventDefault();
            e.originalEvent.stopPropagation();
          });
          setMapHeight();
          (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_2__.initializeLayers)();
          createControls();
          _context.next = 8;
          return (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_2__.loadFeatures)().then(function () {
            layersets = (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_2__.getAllLayers)();
            zoomToAllLayers();
          });
        case 8:
          map.on('popupclose', function () {
            $(document).find(".color-picker").spectrum("hide");
            $('.title-control').show();
          });
        case 9:
        case "end":
          return _context.stop();
      }
    }, _callee);
  }));
  return _initializeMap.apply(this, arguments);
}
function setMapHeight() {
  if ($(window).width() < 768) {
    $('#map').css('height', 'calc(-75px + 100vh)');
  } else {
    $('#map').css('height', 'calc(-45px + 100vh)');
  }
  map.invalidateSize();
}
function zoomToAllLayers() {
  var ctr = null;
  var bounds = [];
  (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_2__.getAllLayers)().forEach(function (l) {
    if (l.getLayers().length > 0) {
      var b = l.getBounds();
      if (b.isValid()) {
        bounds.push(b);
      }
    }
  });
  if (bounds.length > 0) {
    ctr = bounds[0];
    for (var i = 1; i < bounds.length; i++) {
      ctr = ctr.extend(bounds[i]);
    }
  }
  ctr ? map.fitBounds(ctr, {
    padding: [40, 40]
  }) : map.setView([39.8283, -98.5795], 4);
}
function createControls() {
  L.Marker.prototype.options.icon = (0,_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_3__.createIcon)('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE');
  var drawControl = new L.Control.Draw({
    draw: {
      polyline: true,
      polygon: true,
      rectangle: true,
      circle: true,
      marker: true,
      circlemarker: false
    }
  });
  map.addControl(drawControl);
  map.on('draw:created', function (e) {
    var layerset = (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_2__.getLayerset)(e.layerType);
    _objectManager_js__WEBPACK_IMPORTED_MODULE_0__.addObject(e, layerset);
  });
  addTopCenterPosition();
  var TitleControl = L.Control.extend({
    onAdd: function onAdd() {
      var titleDiv = L.DomUtil.create('div', 'leaflet-control title-control');
      var $title = document.getElementById('map-title');
      if ($title) {
        titleDiv.innerHTML = $title.innerHTML;
      }
      L.DomEvent.disableClickPropagation(titleDiv);
      $(document).on('click', '.map-toggle', function (e) {
        /*console.log('click')*/
        $('.map-info').toggleClass('d-none');
        e.stopPropagation();
      });
      _objectManager_js__WEBPACK_IMPORTED_MODULE_0__.mapFormUtil.setFormListeners('#mapForm');
      return titleDiv;
    }
  });
  map.addControl(new TitleControl({
    position: 'topcenter'
  }));
}
function addTopCenterPosition() {
  L.Control.Position = Object.assign(L.Control.Position || {}, {
    TOPCENTER: 'topcenter'
  });
  L.Map.mergeOptions({
    controlPositions: {
      topcenter: L.Control.Position.TOPCENTER
    }
  });
  L.Control.include({
    _setPosition: function _setPosition(position) {
      var map = this._map;
      var pos = map._controlCorners[position];
      if (!pos) return;
      L.DomUtil.addClass(this._container, 'leaflet-control');
      pos.appendChild(this._container);
    }
  });
  map._controlCorners.topcenter = L.DomUtil.create('div', 'leaflet-top leaflet-center', map._controlContainer);
}
})();

/******/ })()
;
//# sourceMappingURL=mapPage.bundle.js.map