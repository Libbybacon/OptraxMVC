/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./wwwroot/js/location/location.js":
/*!*****************************************!*\
  !*** ./wwwroot/js/location/location.js ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _map_mapState_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../map/mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _locationTree_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./locationTree.js */ "./wwwroot/js/location/locationTree.js");
/* harmony import */ var _locationUtil_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./locationUtil.js */ "./wwwroot/js/location/locationUtil.js");




var map = null;
$(function () {
  _locationTree_js__WEBPACK_IMPORTED_MODULE_0__.initializeTree(map);
  _locationUtil_js__WEBPACK_IMPORTED_MODULE_1__.setLocListeners();
  (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_2__.onMapReady)(function (loadedMap) {
    map = loadedMap;
    setResizer();
  });
  (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_2__.onLayersReady)(function (ready) {
    setTimeout(function () {
      _locationUtil_js__WEBPACK_IMPORTED_MODULE_1__.zoomToSite(map);
    }, 500);
  });
});
function setResizer() {
  //console.log('setResizer map', map)
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

/***/ }),

/***/ "./wwwroot/js/location/locationTree.js":
/*!*********************************************!*\
  !*** ./wwwroot/js/location/locationTree.js ***!
  \*********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   initializeTree: () => (/* binding */ initializeTree),
/* harmony export */   nodeMenu: () => (/* binding */ nodeMenu)
/* harmony export */ });
/* harmony import */ var _locationUtil_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./locationUtil.js */ "./wwwroot/js/location/locationUtil.js");

var childTypes = {
  site: ["Field", "Greenhouse", "Building"],
  greenhouse: ["Row"],
  field: ["Row"],
  row: ["Bed"],
  bed: ["Plot"],
  plot: [],
  building: ["Room"],
  room: []
};
function initializeTree() {
  $('#locationTree').jstree({
    'core': {
      'data': {
        'url': './Locations/GetLocationTreeData',
        'dataType': 'json'
      },
      "check_callback": true
    },
    'types': {
      'site': {
        'icon': 'fa-regular fa-font-awesome'
      },
      'field': {
        'icon': 'fas fa-tractor'
      },
      'greenhouse': {
        'icon': 'bi bi-house'
      },
      'building': {
        'icon': 'fas fa-building'
      },
      'room': {
        'icon': 'bi bi-door-open'
      }
    },
    'plugins': ['types', 'contextmenu'],
    'contextmenu': {
      'select_node': false,
      'items': nodeMenu
    }
  });
}
function nodeMenu(node) {
  var nodeType = node.type;
  var childOpts = childTypes[nodeType] || [];
  console.log('nodeMenu node', node, ' type ', nodeType, ' opts ', childOpts);
  var items = {};
  childOpts.forEach(function (type) {
    items["add_".concat(type)] = {
      label: "Add ".concat(type),
      action: function action() {
        (0,_locationUtil_js__WEBPACK_IMPORTED_MODULE_0__.loadCreate)(node.id, type);
      }
    };
  });
  console.log('nodeMenu items');
  return items;
}
function deleteNode(id, type) {
  var tree = $('#locationTree').jstree(true);
  var node = tree.get_node(id);
  var parentId = tree.get_parent(node);
  tree.delete_node(node);
  if (parentId != '#') {
    tree.select_node(parentId);
  } else {
    var firstSite = allNodes.find(function (node) {
      return node.type === 'site';
    });
    if (firstSite) {
      tree.deselect_all();
      tree.select_node(firstSite.id);
    }
  }
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
/* harmony export */   loadCreate: () => (/* binding */ loadCreate),
/* harmony export */   loadPartial: () => (/* binding */ loadPartial),
/* harmony export */   onDelete: () => (/* binding */ onDelete),
/* harmony export */   onSubmitForm: () => (/* binding */ onSubmitForm),
/* harmony export */   setAddyLatLng: () => (/* binding */ setAddyLatLng),
/* harmony export */   setFormListeners: () => (/* binding */ setFormListeners),
/* harmony export */   setLocListeners: () => (/* binding */ setLocListeners),
/* harmony export */   zoomToSite: () => (/* binding */ zoomToSite)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
/* harmony import */ var _utilities_form_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../utilities/form.js */ "./wwwroot/js/utilities/form.js");
/* harmony import */ var _map_map_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../map/map.js */ "./wwwroot/js/map/map.js");
/* harmony import */ var _map_mapState_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../map/mapState.js */ "./wwwroot/js/map/mapState.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var formId = '#locForm';
var urlBase = '/Grow/Locations/';
function loadCreate(parentId, type) {
  var props = {
    action: 'LoadCreate',
    data: {
      type: type,
      parentId: parentId
    }
  };
  loadPartial(props).then = function () {
    setFormListeners();
  };
}
function loadPartial(_x) {
  return _loadPartial.apply(this, arguments);
}
function _loadPartial() {
  _loadPartial = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(props) {
    var response, view, map;
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
          if (view) {
            $("#loc-details").html(view);
            setFormListeners();
            map = (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getMap)();
            zoomToSite(map);
          }
        case 11:
        case "end":
          return _context.stop();
      }
    }, _callee);
  }));
  return _loadPartial.apply(this, arguments);
}
function setLocListeners() {
  $('#add-new-loc').on('click', function () {
    loadCreate(null, 'site');
  });
  $('#locationTree').on("select_node.jstree", function (e, data) {
    var props = {
      action: 'GetDetails',
      data: {
        id: data.node.id,
        type: data.node.type
      }
    };
    loadPartial(props);
  });
  setFormListeners();
}
function setFormListeners() {
  $(formId + ' #Name').on('input', function () {
    $(formId + ' #Address_Name').val($(this).val()).trigger('change');
  });
  $(formId).find('.btn-red').off('click').on('click', function () {
    var id = $(formId).data('id');
    var type = $(formId).data('type');
    onDelete(id, type);
  });
  $(formId).find('.edit-btn').off('click').on('click', function () {
    setTimeout(function () {
      setAddyLatLng();
    }, 100);
  });
  $(formId).off('submit').on('submit', function (e) {
    e.preventDefault();
    onSubmitForm(); // submit form
  });
  _utilities_form_js__WEBPACK_IMPORTED_MODULE_2__.formUtil.setListeners(formId);
  $(formId).find('.addy').on('change', function () {
    console.log('addy change');
    setAddyLatLng();
  });
}
function onDelete(_x2, _x3) {
  return _onDelete.apply(this, arguments);
}
function _onDelete() {
  _onDelete = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2(id, type) {
    var response, _response$msg, msg;
    return _regeneratorRuntime().wrap(function _callee2$(_context2) {
      while (1) switch (_context2.prev = _context2.next) {
        case 0:
          _context2.next = 2;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_0__["default"].get("".concat(urlBase, "Delete/"), {
            id: id
          });
        case 2:
          response = _context2.sent;
          if (response && response.success) {
            window.showMessage({
              msg: "".concat(locType, " Deleted!"),
              css: 'success msg',
              msgdiv: $('.loc-msg')
            });
          } else {
            msg = (_response$msg = response.msg) !== null && _response$msg !== void 0 ? _response$msg : "Error deleting " + type;
            window.showMessage({
              msg: msg,
              css: 'error msg',
              msgdiv: $('.loc-msg')
            });
          }
        case 4:
        case "end":
          return _context2.stop();
      }
    }, _callee2);
  }));
  return _onDelete.apply(this, arguments);
}
function onSubmitForm() {
  return _onSubmitForm.apply(this, arguments);
}
function _onSubmitForm() {
  _onSubmitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee3() {
    var action, locType, isCreate, response, tree, msgTxt;
    return _regeneratorRuntime().wrap(function _callee3$(_context3) {
      while (1) switch (_context3.prev = _context3.next) {
        case 0:
          action = $(formId).attr('action');
          locType = $(formId).find('.loc-type').val();
          isCreate = action && action.includes('Create'); //console.log('loc onSubmitForm objType: ', locType, ' action:', action);
          _context3.next = 5;
          return _utilities_form_js__WEBPACK_IMPORTED_MODULE_2__.formUtil.submitForm(formId);
        case 5:
          response = _context3.sent;
          console.log('loc onSubmitForm response', response);
          if (response && response.success) {
            if (isCreate) {
              (0,_map_map_js__WEBPACK_IMPORTED_MODULE_3__.addSitePoint)($('.addy-lat').val(), $('.addy-lng').val(), $(formId).find('.loc-name').val());
              if (response.data) {
                console.log('response.data', response.data);
                $(formId + ' #Id').val(response.data.id);
                tree = $('#locationTree').jstree(true);
                tree.create_node(response.data.parent, response.data, "last", function (newNode) {
                  //console.log('newnode:', newNode);
                  newNode.parents.forEach(function (id) {
                    tree.open_node(id);
                  });
                  tree.deselect_all();
                  tree.select_node(newNode.id);
                });
              }
            }
            $(formId + ' .m-toggle').toggleClass('d-none');
            msgTxt = isCreate ? 'Created' : 'Updated';
            window.showMessage({
              msg: "".concat(locType, " ").concat(msgTxt, "!"),
              css: 'success msg',
              msgdiv: $('.loc-msg')
            });
          } else {
            alert('Error! ' + response.error);
          }
        case 8:
        case "end":
          return _context3.stop();
      }
    }, _callee3);
  }));
  return _onSubmitForm.apply(this, arguments);
}
function setAddyLatLng() {
  console.log('setAddyLatLng');
  // Check whether all components of address are filled
  var addyArr = [$('.addy-street1').val(), $('.addy-city').val(), $('.addy-state').val(), $('.addy-zip').val()];
  var hasEmpty = addyArr.some(function (a) {
    return a === null || a === undefined || a.trim() === '';
  });
  if (!hasEmpty) {
    var address = addyArr.join(', ');

    // Get address lat, lng, zoom to loc on map, set form values
    geocodeAddress(address, function (err, result) {
      console.log('geocode result', result, 'address', address);
      if (err) {
        console.log('geocode error');
        return;
      }
      var lat = result.lat,
        lon = result.lon;
      var map = (0,_map_mapState_js__WEBPACK_IMPORTED_MODULE_1__.getMap)();
      map.setView([lat, lon], 21);
      $('.addy-lat').val(lat).trigger('change');
      $('.addy-lng').val(lon).trigger('change');
    });
  }
}
function geocodeAddress(address, callback) {
  var url = "https://nominatim.openstreetmap.org/search?format=json&q=".concat(encodeURIComponent(address));
  fetch(url, {
    headers: {
      'User-Agent': 'OptraxApp/1.0 (optrax@optrax.dev)'
    }
  }).then(function (res) {
    return res.json();
  }).then(function (data) {
    if (data.length > 0) {
      var lat = parseFloat(data[0].lat);
      var lon = parseFloat(data[0].lon);
      callback(null, {
        lat: lat,
        lon: lon
      });
    } else {
      callback("No results found");
    }
  })["catch"](function (err) {
    return callback(err);
  });
}
function zoomToSite(map) {
  var lat = parseFloat($('#locForm').find('.addy-lat').val());
  var lng = parseFloat($('#locForm').find('.addy-lng').val());

  //console.log('delayed zoomToSite lat', lat, 'lng', lng);

  if (!isNaN(lat) && !isNaN(lng)) {
    map.invalidateSize();
    map.setView([lat, lng], 21);
    //console.log('zoomed after delay:', map.getCenter());
  }
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
/* harmony export */   getLayerCenter: () => (/* binding */ getLayerCenter),
/* harmony export */   getLayerset: () => (/* binding */ getLayerset),
/* harmony export */   initializeLayers: () => (/* binding */ initializeLayers),
/* harmony export */   loadFeatures: () => (/* binding */ loadFeatures),
/* harmony export */   loadObjects: () => (/* binding */ loadObjects),
/* harmony export */   setActions: () => (/* binding */ setActions),
/* harmony export */   setClickHandlers: () => (/* binding */ setClickHandlers),
/* harmony export */   setStyle: () => (/* binding */ setStyle),
/* harmony export */   setType: () => (/* binding */ setType)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
/* harmony import */ var _objectManager_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./objectManager.js */ "./wwwroot/js/map/objectManager.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var pointsL, linesL, polysL, circlesL;
var map = null;
function initializeLayers() {
  map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getMap)();

  //console.log('initializeLayers map: ', map)
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

  //console.log('initializeLayers map: ', map)

  pointsL = L.geoJSON(null, {
    pointToLayer: function pointToLayer(feat, latlng) {
      console.log('pointToLayer feat', feat);
      var icon = (0,_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_1__.createIcon)(feat.properties.iconPath);
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
      //console.log('lineFeature feat', feat);
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
      //console.log('circleFeature feat', feat);
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
      //console.log('polyFeature feat', feat);
      setType(feat, 'Polygon');
      setActions(feat.properties, l);
    }
  }).addTo(map);
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setMap)(map);
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
  var id = props.id;
  var type = props.objType;
  var isCircle = type == 'Circle';
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setIndex)(id, layer);
  var editProps = {
    type: type,
    data: {
      id: id,
      objType: type
    },
    url: "".concat(_objectManager_js__WEBPACK_IMPORTED_MODULE_2__.urlBase, "LoadEdit/")
  };
  layer.bindTooltip(props.name, {
    permanent: true,
    direction: "top"
  });

  //layer.on('drag', function () {
  //    layer.closeTooltip();
  //});

  //layer.on('dragend', function () {
  //    // Re-center and show tooltip
  //    const center = getLayerCenter(layer); 
  //    layer.setTooltipLatLng(center);  
  //    layer.openTooltip();
  //});

  setClickHandlers(layer, function (e) {
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setActive)(layer);
    editProps["center"] = getLayerCenter(layer);
    editProps["radius"] = isCircle ? layer.getRadius() : null;
    console.log('setClickHandlers single editProps', editProps);
    (0,_objectManager_js__WEBPACK_IMPORTED_MODULE_2__.loadEdit)(editProps);
  }, function (e) {
    if (layer.enableEdit) {
      (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setActive)(layer);
      (0,_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_1__.saveStyle)();
      layer.enableEdit();
      layer.once('editable:disable', function () {
        editProps["center"] = getLayerCenter(layer);
        editProps["radius"] = isCircle ? layer.getRadius() : null;
        console.log('setClickHandlers dbl editProps', editProps);
        (0,_objectManager_js__WEBPACK_IMPORTED_MODULE_2__.loadEdit)(editProps);
      });
    }
  });

  //// Center map on selected object
  //layer.on('click', async function (e) {
  //    setActive(layer);
  //    const center = (type === 'Point' || type === 'Circle') ? e.latlng : layer.getBounds().getCenter();

  //    loadEdit(props.id, type, center);
  //});

  layer.on('remove', function () {
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.deleteIndex)(props.id);
    var map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getMap)();
    map.closePopup();
  });
}
function getLayerCenter(layer) {
  if (layer.getBounds) {
    return layer.getBounds().getCenter(); // line or poly
  }
  if (layer.getLatLng) {
    return layer.getLatLng(); // point or circle
  }
  return null;
}
function setClickHandlers(layer, onClick, onDblClick) {
  var delay = arguments.length > 3 && arguments[3] !== undefined ? arguments[3] : 250;
  var clickTimer = null;
  layer.on('click', function (e) {
    if (clickTimer) return;
    clickTimer = setTimeout(function () {
      clickTimer = null;
      onClick(e);
    }, delay);
  });
  layer.on('dblclick', function (e) {
    if (clickTimer) {
      clearTimeout(clickTimer);
      clickTimer = null;
    }
    onDblClick(e);
  });
}
function loadFeatures() {
  return _loadFeatures.apply(this, arguments);
}
function _loadFeatures() {
  _loadFeatures = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee() {
    return _regeneratorRuntime().wrap(function _callee$(_context) {
      while (1) switch (_context.prev = _context.next) {
        case 0:
          _context.next = 2;
          return loadObjects(pointsL, 'Point');
        case 2:
          _context.next = 4;
          return loadObjects(linesL, 'Line');
        case 4:
          _context.next = 6;
          return loadObjects(polysL, 'Polygon');
        case 6:
          _context.next = 8;
          return loadObjects(circlesL, 'Circle');
        case 8:
        case "end":
          return _context.stop();
      }
    }, _callee);
  }));
  return _loadFeatures.apply(this, arguments);
}
function loadObjects(_x, _x2) {
  return _loadObjects.apply(this, arguments);
}
function _loadObjects() {
  _loadObjects = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2(mapLayer, layerType) {
    var response;
    return _regeneratorRuntime().wrap(function _callee2$(_context2) {
      while (1) switch (_context2.prev = _context2.next) {
        case 0:
          _context2.prev = 0;
          _context2.next = 3;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_3__["default"].get('/Grow/Map/GetObjects', {
            objType: layerType
          });
        case 3:
          response = _context2.sent;
          if (!(response.success === false)) {
            _context2.next = 7;
            break;
          }
          alert("Failed to load ".concat(layerType.toLowerCase(), "s"));
          throw new Error(response.error || "Failed to load ".concat(layerType.toLowerCase(), "s"));
        case 7:
          mapLayer.addData(response.data);
          _context2.next = 13;
          break;
        case 10:
          _context2.prev = 10;
          _context2.t0 = _context2["catch"](0);
          console.error("Error loading ".concat(layerType, "s:"), _context2.t0);
        case 13:
        case "end":
          return _context2.stop();
      }
    }, _callee2, null, [[0, 10]]);
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
function getAllLayers() {
  return [pointsL, linesL, circlesL, polysL];
}

/***/ }),

/***/ "./wwwroot/js/map/map.js":
/*!*******************************!*\
  !*** ./wwwroot/js/map/map.js ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   addSitePoint: () => (/* binding */ addSitePoint)
/* harmony export */ });
/* harmony import */ var _objectManager_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./objectManager.js */ "./wwwroot/js/map/objectManager.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _layerManager_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./layerManager.js */ "./wwwroot/js/map/layerManager.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function _regeneratorRuntime() { "use strict"; /*! regenerator-runtime -- Copyright (c) 2014-present, Facebook, Inc. -- license (MIT): https://github.com/facebook/regenerator/blob/main/LICENSE */ _regeneratorRuntime = function _regeneratorRuntime() { return e; }; var t, e = {}, r = Object.prototype, n = r.hasOwnProperty, o = Object.defineProperty || function (t, e, r) { t[e] = r.value; }, i = "function" == typeof Symbol ? Symbol : {}, a = i.iterator || "@@iterator", c = i.asyncIterator || "@@asyncIterator", u = i.toStringTag || "@@toStringTag"; function define(t, e, r) { return Object.defineProperty(t, e, { value: r, enumerable: !0, configurable: !0, writable: !0 }), t[e]; } try { define({}, ""); } catch (t) { define = function define(t, e, r) { return t[e] = r; }; } function wrap(t, e, r, n) { var i = e && e.prototype instanceof Generator ? e : Generator, a = Object.create(i.prototype), c = new Context(n || []); return o(a, "_invoke", { value: makeInvokeMethod(t, r, c) }), a; } function tryCatch(t, e, r) { try { return { type: "normal", arg: t.call(e, r) }; } catch (t) { return { type: "throw", arg: t }; } } e.wrap = wrap; var h = "suspendedStart", l = "suspendedYield", f = "executing", s = "completed", y = {}; function Generator() {} function GeneratorFunction() {} function GeneratorFunctionPrototype() {} var p = {}; define(p, a, function () { return this; }); var d = Object.getPrototypeOf, v = d && d(d(values([]))); v && v !== r && n.call(v, a) && (p = v); var g = GeneratorFunctionPrototype.prototype = Generator.prototype = Object.create(p); function defineIteratorMethods(t) { ["next", "throw", "return"].forEach(function (e) { define(t, e, function (t) { return this._invoke(e, t); }); }); } function AsyncIterator(t, e) { function invoke(r, o, i, a) { var c = tryCatch(t[r], t, o); if ("throw" !== c.type) { var u = c.arg, h = u.value; return h && "object" == _typeof(h) && n.call(h, "__await") ? e.resolve(h.__await).then(function (t) { invoke("next", t, i, a); }, function (t) { invoke("throw", t, i, a); }) : e.resolve(h).then(function (t) { u.value = t, i(u); }, function (t) { return invoke("throw", t, i, a); }); } a(c.arg); } var r; o(this, "_invoke", { value: function value(t, n) { function callInvokeWithMethodAndArg() { return new e(function (e, r) { invoke(t, n, e, r); }); } return r = r ? r.then(callInvokeWithMethodAndArg, callInvokeWithMethodAndArg) : callInvokeWithMethodAndArg(); } }); } function makeInvokeMethod(e, r, n) { var o = h; return function (i, a) { if (o === f) throw Error("Generator is already running"); if (o === s) { if ("throw" === i) throw a; return { value: t, done: !0 }; } for (n.method = i, n.arg = a;;) { var c = n.delegate; if (c) { var u = maybeInvokeDelegate(c, n); if (u) { if (u === y) continue; return u; } } if ("next" === n.method) n.sent = n._sent = n.arg;else if ("throw" === n.method) { if (o === h) throw o = s, n.arg; n.dispatchException(n.arg); } else "return" === n.method && n.abrupt("return", n.arg); o = f; var p = tryCatch(e, r, n); if ("normal" === p.type) { if (o = n.done ? s : l, p.arg === y) continue; return { value: p.arg, done: n.done }; } "throw" === p.type && (o = s, n.method = "throw", n.arg = p.arg); } }; } function maybeInvokeDelegate(e, r) { var n = r.method, o = e.iterator[n]; if (o === t) return r.delegate = null, "throw" === n && e.iterator["return"] && (r.method = "return", r.arg = t, maybeInvokeDelegate(e, r), "throw" === r.method) || "return" !== n && (r.method = "throw", r.arg = new TypeError("The iterator does not provide a '" + n + "' method")), y; var i = tryCatch(o, e.iterator, r.arg); if ("throw" === i.type) return r.method = "throw", r.arg = i.arg, r.delegate = null, y; var a = i.arg; return a ? a.done ? (r[e.resultName] = a.value, r.next = e.nextLoc, "return" !== r.method && (r.method = "next", r.arg = t), r.delegate = null, y) : a : (r.method = "throw", r.arg = new TypeError("iterator result is not an object"), r.delegate = null, y); } function pushTryEntry(t) { var e = { tryLoc: t[0] }; 1 in t && (e.catchLoc = t[1]), 2 in t && (e.finallyLoc = t[2], e.afterLoc = t[3]), this.tryEntries.push(e); } function resetTryEntry(t) { var e = t.completion || {}; e.type = "normal", delete e.arg, t.completion = e; } function Context(t) { this.tryEntries = [{ tryLoc: "root" }], t.forEach(pushTryEntry, this), this.reset(!0); } function values(e) { if (e || "" === e) { var r = e[a]; if (r) return r.call(e); if ("function" == typeof e.next) return e; if (!isNaN(e.length)) { var o = -1, i = function next() { for (; ++o < e.length;) if (n.call(e, o)) return next.value = e[o], next.done = !1, next; return next.value = t, next.done = !0, next; }; return i.next = i; } } throw new TypeError(_typeof(e) + " is not iterable"); } return GeneratorFunction.prototype = GeneratorFunctionPrototype, o(g, "constructor", { value: GeneratorFunctionPrototype, configurable: !0 }), o(GeneratorFunctionPrototype, "constructor", { value: GeneratorFunction, configurable: !0 }), GeneratorFunction.displayName = define(GeneratorFunctionPrototype, u, "GeneratorFunction"), e.isGeneratorFunction = function (t) { var e = "function" == typeof t && t.constructor; return !!e && (e === GeneratorFunction || "GeneratorFunction" === (e.displayName || e.name)); }, e.mark = function (t) { return Object.setPrototypeOf ? Object.setPrototypeOf(t, GeneratorFunctionPrototype) : (t.__proto__ = GeneratorFunctionPrototype, define(t, u, "GeneratorFunction")), t.prototype = Object.create(g), t; }, e.awrap = function (t) { return { __await: t }; }, defineIteratorMethods(AsyncIterator.prototype), define(AsyncIterator.prototype, c, function () { return this; }), e.AsyncIterator = AsyncIterator, e.async = function (t, r, n, o, i) { void 0 === i && (i = Promise); var a = new AsyncIterator(wrap(t, r, n, o), i); return e.isGeneratorFunction(r) ? a : a.next().then(function (t) { return t.done ? t.value : a.next(); }); }, defineIteratorMethods(g), define(g, u, "Generator"), define(g, a, function () { return this; }), define(g, "toString", function () { return "[object Generator]"; }), e.keys = function (t) { var e = Object(t), r = []; for (var n in e) r.push(n); return r.reverse(), function next() { for (; r.length;) { var t = r.pop(); if (t in e) return next.value = t, next.done = !1, next; } return next.done = !0, next; }; }, e.values = values, Context.prototype = { constructor: Context, reset: function reset(e) { if (this.prev = 0, this.next = 0, this.sent = this._sent = t, this.done = !1, this.delegate = null, this.method = "next", this.arg = t, this.tryEntries.forEach(resetTryEntry), !e) for (var r in this) "t" === r.charAt(0) && n.call(this, r) && !isNaN(+r.slice(1)) && (this[r] = t); }, stop: function stop() { this.done = !0; var t = this.tryEntries[0].completion; if ("throw" === t.type) throw t.arg; return this.rval; }, dispatchException: function dispatchException(e) { if (this.done) throw e; var r = this; function handle(n, o) { return a.type = "throw", a.arg = e, r.next = n, o && (r.method = "next", r.arg = t), !!o; } for (var o = this.tryEntries.length - 1; o >= 0; --o) { var i = this.tryEntries[o], a = i.completion; if ("root" === i.tryLoc) return handle("end"); if (i.tryLoc <= this.prev) { var c = n.call(i, "catchLoc"), u = n.call(i, "finallyLoc"); if (c && u) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } else if (c) { if (this.prev < i.catchLoc) return handle(i.catchLoc, !0); } else { if (!u) throw Error("try statement without catch or finally"); if (this.prev < i.finallyLoc) return handle(i.finallyLoc); } } } }, abrupt: function abrupt(t, e) { for (var r = this.tryEntries.length - 1; r >= 0; --r) { var o = this.tryEntries[r]; if (o.tryLoc <= this.prev && n.call(o, "finallyLoc") && this.prev < o.finallyLoc) { var i = o; break; } } i && ("break" === t || "continue" === t) && i.tryLoc <= e && e <= i.finallyLoc && (i = null); var a = i ? i.completion : {}; return a.type = t, a.arg = e, i ? (this.method = "next", this.next = i.finallyLoc, y) : this.complete(a); }, complete: function complete(t, e) { if ("throw" === t.type) throw t.arg; return "break" === t.type || "continue" === t.type ? this.next = t.arg : "return" === t.type ? (this.rval = this.arg = t.arg, this.method = "return", this.next = "end") : "normal" === t.type && e && (this.next = e), y; }, finish: function finish(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.finallyLoc === t) return this.complete(r.completion, r.afterLoc), resetTryEntry(r), y; } }, "catch": function _catch(t) { for (var e = this.tryEntries.length - 1; e >= 0; --e) { var r = this.tryEntries[e]; if (r.tryLoc === t) { var n = r.completion; if ("throw" === n.type) { var o = n.arg; resetTryEntry(r); } return o; } } throw Error("illegal catch attempt"); }, delegateYield: function delegateYield(e, r, n) { return this.delegate = { iterator: values(e), resultName: r, nextLoc: n }, "next" === this.method && (this.arg = t), y; } }, e; }
function asyncGeneratorStep(n, t, e, r, o, a, c) { try { var i = n[a](c), u = i.value; } catch (n) { return void e(n); } i.done ? t(u) : Promise.resolve(u).then(r, o); }
function _asyncToGenerator(n) { return function () { var t = this, e = arguments; return new Promise(function (r, o) { var a = n.apply(t, e); function _next(n) { asyncGeneratorStep(a, r, o, _next, _throw, "next", n); } function _throw(n) { asyncGeneratorStep(a, r, o, _next, _throw, "throw", n); } _next(void 0); }); }; }




var map = null;
var layersets = [];
$(function () {
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
            zoom: 4,
            editable: true
          });
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setMap)(map);
          map.on('click', function (e) {
            e.originalEvent.preventDefault();
            e.originalEvent.stopPropagation();
          });
          setMapHeight();
          _layerManager_js__WEBPACK_IMPORTED_MODULE_1__.initializeLayers();
          createControls();
          _context.next = 8;
          return _layerManager_js__WEBPACK_IMPORTED_MODULE_1__.loadFeatures().then(function () {
            layersets = _layerManager_js__WEBPACK_IMPORTED_MODULE_1__.getAllLayers();
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

// Center map on center of all layers
function zoomToAllLayers() {
  var ctr = null;
  var bounds = [];
  _layerManager_js__WEBPACK_IMPORTED_MODULE_1__.getAllLayers().forEach(function (l) {
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
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setLayersReady)(true);
}
function createControls() {
  L.Marker.prototype.options.icon = (0,_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.createIcon)('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE');

  //const drawControl = new L.Control.Draw({
  //    draw: {
  //        polyline: true,
  //        polygon: true,
  //        rectangle: true,
  //        circle: true,
  //        marker: true,
  //        circlemarker: false
  //    }
  //});
  //map.addControl(drawControl);

  //map.on('draw:created', function (e) {
  //    _obj.addObject(e.layer, e.layerType);

  //});

  addTopCenterPosition();
  var titleControl = L.Control.extend({
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
      _objectManager_js__WEBPACK_IMPORTED_MODULE_3__.mapFormUtil.setFormListeners('#mapForm');
      return titleDiv;
    }
  });
  map.addControl(new titleControl({
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
function addSitePoint(lng, lat, name) {
  var props = _objectManager_js__WEBPACK_IMPORTED_MODULE_3__.layerProps;
  props["name"] = name;
  var sitePoint = {
    type: "Feature",
    properties: props,
    geometry: {
      type: "Point",
      coordinates: [lng, lat]
    }
  };
  var pointsL = _layerManager_js__WEBPACK_IMPORTED_MODULE_1__.getLayerset('marker');
  console.log('addSitePoint sitePoint', sitePoint);
  pointsL.addData(sitePoint);
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
/* harmony export */   notifyLayerSubscribers: () => (/* binding */ notifyLayerSubscribers),
/* harmony export */   onLayersReady: () => (/* binding */ onLayersReady),
/* harmony export */   onMapReady: () => (/* binding */ onMapReady),
/* harmony export */   setActive: () => (/* binding */ setActive),
/* harmony export */   setIndex: () => (/* binding */ setIndex),
/* harmony export */   setLayersReady: () => (/* binding */ setLayersReady),
/* harmony export */   setMap: () => (/* binding */ setMap)
/* harmony export */ });
function _createForOfIteratorHelper(r, e) { var t = "undefined" != typeof Symbol && r[Symbol.iterator] || r["@@iterator"]; if (!t) { if (Array.isArray(r) || (t = _unsupportedIterableToArray(r)) || e && r && "number" == typeof r.length) { t && (r = t); var _n = 0, F = function F() {}; return { s: F, n: function n() { return _n >= r.length ? { done: !0 } : { done: !1, value: r[_n++] }; }, e: function e(r) { throw r; }, f: F }; } throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); } var o, a = !0, u = !1; return { s: function s() { t = t.call(r); }, n: function n() { var r = t.next(); return a = r.done, r; }, e: function e(r) { u = !0, o = r; }, f: function f() { try { a || null == t["return"] || t["return"](); } finally { if (u) throw o; } } }; }
function _unsupportedIterableToArray(r, a) { if (r) { if ("string" == typeof r) return _arrayLikeToArray(r, a); var t = {}.toString.call(r).slice(8, -1); return "Object" === t && r.constructor && (t = r.constructor.name), "Map" === t || "Set" === t ? Array.from(r) : "Arguments" === t || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(t) ? _arrayLikeToArray(r, a) : void 0; } }
function _arrayLikeToArray(r, a) { (null == a || a > r.length) && (a = r.length); for (var e = 0, n = Array(a); e < a; e++) n[e] = r[e]; return n; }
var map = null;
var activeL = null;
var layersReady = false;
var subscribers = [];
var layerSubs = [];
var layerIndex = new Map();
function setMap(newMap) {
  map = newMap;
  notifySubscribers();
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
function setLayersReady(ready) {
  //console.log('setLayersReady', ready);
  layersReady = ready;
  notifyLayerSubscribers();
}
function onLayersReady(callback) {
  if (layersReady) {
    callBack(layersReady);
  } else {
    layerSubs.push(callback);
  }
}
function notifyLayerSubscribers() {
  var _iterator2 = _createForOfIteratorHelper(layerSubs),
    _step2;
  try {
    for (_iterator2.s(); !(_step2 = _iterator2.n()).done;) {
      var cb = _step2.value;
      cb(layersReady);
    }
  } catch (err) {
    _iterator2.e(err);
  } finally {
    _iterator2.f();
  }
  layerSubs.length = 0;
}
function getMap() {
  return map;
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
/* harmony import */ var _utilities_color_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../utilities/color.js */ "./wwwroot/js/utilities/color.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
function ownKeys(e, r) { var t = Object.keys(e); if (Object.getOwnPropertySymbols) { var o = Object.getOwnPropertySymbols(e); r && (o = o.filter(function (r) { return Object.getOwnPropertyDescriptor(e, r).enumerable; })), t.push.apply(t, o); } return t; }
function _objectSpread(e) { for (var r = 1; r < arguments.length; r++) { var t = null != arguments[r] ? arguments[r] : {}; r % 2 ? ownKeys(Object(t), !0).forEach(function (r) { _defineProperty(e, r, t[r]); }) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(t)) : ownKeys(Object(t)).forEach(function (r) { Object.defineProperty(e, r, Object.getOwnPropertyDescriptor(t, r)); }); } return e; }
function _defineProperty(e, r, t) { return (r = _toPropertyKey(r)) in e ? Object.defineProperty(e, r, { value: t, enumerable: !0, configurable: !0, writable: !0 }) : e[r] = t, e; }
function _toPropertyKey(t) { var i = _toPrimitive(t, "string"); return "symbol" == _typeof(i) ? i : i + ""; }
function _toPrimitive(t, r) { if ("object" != _typeof(t) || !t) return t; var e = t[Symbol.toPrimitive]; if (void 0 !== e) { var i = e.call(t, r || "default"); if ("object" != _typeof(i)) return i; throw new TypeError("@@toPrimitive must return a primitive value."); } return ("string" === r ? String : Number)(t); }


var formId = '#mapObjForm';
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
  $('.obj-iconId').val($icon.data('iconid')).trigger('change');
  $icon.addClass('selected');
  var imgURL = $icon.find('img').attr('src');
  var props = {
    iconURL: imgURL,
    marker: (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)(),
    title: $('.obj-name').val(),
    desc: $('.obj-details').val()
  };
  updateIcon(props);
}
function selectIconColl($coll) {
  var collId = $coll.data('collid');
  $('.icon-coll-name').removeClass('selected');
  $(".coll-name-".concat(collId)).addClass('selected');
  $('.preview-div').addClass('d-none');
  $(".preview-div.preview-coll-".concat(collId)).removeClass('d-none');
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
    selectionPalette: [_utilities_color_js__WEBPACK_IMPORTED_MODULE_1__.colorSwatches],
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
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)();
  //console.log('updateStyle layer', layer, 'input', input, 'val', val);
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
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)();
  var tooltip = layer.getTooltip();
  //console.log('saveStyle');
  layer._origStyle = {
    icon: layer instanceof L.Marker ? layer.getIcon() : null,
    style: layer.setStyle ? _objectSpread({}, layer.options) : null,
    content: tooltip === null || tooltip === void 0 ? void 0 : tooltip.getContent(),
    geometry: getGeometrySnapshot(layer)
  };
}
function restoreStyle(input, val) {
  var l = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)();
  var orig = l._origStyle;
  var tooltip = l.getTooltip();
  if (l instanceof L.Marker && orig.icon) {
    l.setIcon(orig.icon);
    l._tooltip.setContent();
  } else if (l.setStyle && orig.style) {
    l.setStyle(orig.style);
  }
  if (tooltip) {
    tooltip.setContent(orig.content);
  }
  restoreGeometry(l, orig.geometry);
  delete l._originalStyle;
}
function getGeometrySnapshot(layer) {
  if (layer instanceof L.Marker) {
    return {
      latlng: layer.getLatLng()
    };
  }
  if (layer instanceof L.Circle) {
    return {
      latlng: layer.getLatLng(),
      radius: layer.getRadius()
    };
  }
  if (layer.getLatLngs) {
    return {
      latlngs: layer.getLatLngs()
    };
  }
  return null;
}
function restoreGeometry(layer, geom) {
  if (!geom) return;
  if (layer instanceof L.Marker && geom.latlng) {
    layer.setLatLng(geom.latlng);
  }
  if (layer instanceof L.Circle && geom.latlng && geom.radius != null) {
    layer.setLatLng(geom.latlng);
    layer.setRadius(geom.radius);
  }
  if (layer.setLatLngs && geom.latlngs) {
    layer.setLatLngs(geom.latlngs);
  }
}
function setStyleListeners(formId) {
  //console.log('setStyleListeners');
  // Points
  $('.icon-coll-name').on('click', function () {
    selectIconColl($(this)); // change icon collection display
  });
  $('.icon-div').on('click', function () {
    selectIcon($(this)); // Update point icon
  });
  $('.point-info').on('input', function () {
    var props = {
      marker: (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)(),
      title: $('#Name').val()
    }; // Change point's tooltip content
    updateIcon(props);
  });

  // Not Points
  $('.obj-pattern').on('change', function () {
    var pattern = $(this).val();
    var $dash = $('.obj-dash');
    if (pattern == 'solid') {
      $dash.val(0).trigger('change');
      $dash.attr('readonly', 'readonly');
    } else {
      $dash.val('5 5').trigger('change');
      $dash.removeAttr('readonly');
    }
    setTimeout(function () {
      updateStyle('dashArray', $dash.val());
    }, 50);
  });
  $('.obj-name').on('input', function () {
    updateStyle('name', $(this).val());
  });
  $('.obj-dash').on('input', function () {
    updateStyle('dashArray', $(this).val());
  });
  $('.obj-weight').on('change', function () {
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
/* harmony export */   addCircle: () => (/* binding */ addCircle),
/* harmony export */   finalizeObject: () => (/* binding */ finalizeObject),
/* harmony export */   getLastLayer: () => (/* binding */ getLastLayer),
/* harmony export */   layerProps: () => (/* binding */ layerProps),
/* harmony export */   loadEdit: () => (/* binding */ loadEdit),
/* harmony export */   mapFormUtil: () => (/* binding */ mapFormUtil),
/* harmony export */   onDelete: () => (/* binding */ onDelete),
/* harmony export */   showEditPopup: () => (/* binding */ showEditPopup),
/* harmony export */   startAddObject: () => (/* binding */ startAddObject),
/* harmony export */   updateHiddenFields: () => (/* binding */ updateHiddenFields),
/* harmony export */   urlBase: () => (/* binding */ urlBase)
/* harmony export */ });
/* harmony import */ var _utilities_api_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../utilities/api.js */ "./wwwroot/js/utilities/api.js");
/* harmony import */ var _utilities_form_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../utilities/form.js */ "./wwwroot/js/utilities/form.js");
/* harmony import */ var _mapState_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./mapState.js */ "./wwwroot/js/map/mapState.js");
/* harmony import */ var _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./objStyleUtil.js */ "./wwwroot/js/map/objStyleUtil.js");
/* harmony import */ var _layerManager_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./layerManager.js */ "./wwwroot/js/map/layerManager.js");
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





var map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getMap)();
$(function () {
  (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.onMapReady)(function (loadedMap) {
    map = loadedMap;
  });
});
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
//layer.feature = {
//    type: 'Feature',
//    properties: { ...layerProps },
//    geometry: {} // Leaflet will populate this
//};
// Called when user clicks 'Add to Map' or map toolbar button
// Starts drawing new object.

function startAddObject(type) {
  var layer;
  switch (type) {
    case 'marker':
      layer = map.editTools.startMarker();
      break;
    case 'polyline':
      layer = map.editTools.startPolyline();
      break;
    case 'polygon':
      layer = map.editTools.startPolygon();
      break;
    case 'circle':
      var center = map.getCenter();
      layer = L.circle(center, {
        radius: 10
      }).addTo(map);
      layer.enableEdit();
      layer.dragging.enable();
      //finalizeObject(layer, type);
      return;
  }
  if (layer) {
    layer.on('editable:drawing:end', function () {
      finalizeObject(layer, type);
    });
  }
}
function finalizeObject(_x, _x2) {
  return _finalizeObject.apply(this, arguments);
}
function _finalizeObject() {
  _finalizeObject = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee2(layer, type) {
    var _typeMap$type;
    var layerSet, objType, geojson, newLayer, props;
    return _regeneratorRuntime().wrap(function _callee2$(_context2) {
      while (1) switch (_context2.prev = _context2.next) {
        case 0:
          console.log('finalizeObject layer', layer, 'type', type);
          layerSet = (0,_layerManager_js__WEBPACK_IMPORTED_MODULE_1__.getLayerset)(type);
          objType = (_typeMap$type = typeMap[type]) !== null && _typeMap$type !== void 0 ? _typeMap$type : 'Polygon';
          layerProps["name"] = 'New ' + objType;
          if (type === 'circle') {
            addCircle(layer, layerSet);
          } else {
            geojson = layer.toGeoJSON();
            geojson.properties = layerProps;
            layerSet.addData(geojson);
          }
          newLayer = getLastLayer(layerSet);
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setActive)(newLayer);
          (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setIndex)(-1, newLayer);

          //if (layer.enableEdit) {
          //    layer.enableEdit();
          //}
          props = {
            id: -1,
            type: objType,
            center: getCenter(newLayer),
            radius: type === 'circle' ? layer.getRadius() : null,
            data: {
              objType: objType
            },
            url: "".concat(urlBase, "LoadCreateObject/")
          };
          console.log('finalizeObject props', props);
          loadEdit(props);
        case 11:
        case "end":
          return _context2.stop();
      }
    }, _callee2);
  }));
  return _finalizeObject.apply(this, arguments);
}
function addCircle(l, layerSet) {
  var latlng = l.getLatLng();
  layerProps["radius"] = l.getRadius();
  layerProps['latlng'] = latlng;
  var feature = {
    type: "Feature",
    properties: layerProps,
    geometry: {
      type: "Point",
      coordinates: [latlng.lng, latlng.lat]
    }
  };
  layerSet.addData(feature);
}

// Get currently selected map object
var getLastLayer = function getLastLayer(layerSet) {
  var layers = layerSet.getLayers();
  return layers[layers.length - 1];
};

// Called when user clicks map object once
function loadEdit(_x3) {
  return _loadEdit.apply(this, arguments);
}
function _loadEdit() {
  _loadEdit = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee3(props) {
    return _regeneratorRuntime().wrap(function _callee3$(_context3) {
      while (1) switch (_context3.prev = _context3.next) {
        case 0:
          console.log('loadEdit', props);
          _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.saveStyle(); // Store current style in case user cancels update
          _context3.next = 4;
          return showEditPopup(props).then(function () {
            mapFormUtil.setFormListeners('#mapObjForm');
            updateHiddenFields(props);
            map.on('popupclose', _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.restoreStyle);
          });
        case 4:
        case "end":
          return _context3.stop();
      }
    }, _callee3);
  }));
  return _loadEdit.apply(this, arguments);
}
function showEditPopup(_x4) {
  return _showEditPopup.apply(this, arguments);
}

// Fill in geometry, MapId values in form
function _showEditPopup() {
  _showEditPopup = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee4(props) {
    var response, view, $editDiv;
    return _regeneratorRuntime().wrap(function _callee4$(_context4) {
      while (1) switch (_context4.prev = _context4.next) {
        case 0:
          map = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getMap)();
          _context4.next = 3;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_3__["default"].get(props.url, props.data);
        case 3:
          response = _context4.sent;
          if (!(!response.success == true)) {
            _context4.next = 7;
            break;
          }
          window.showMesage({
            msg: 'Error loading' + props.type,
            msgdiv: $('.map-msg'),
            css: 'error'
          });
          throw new Error("HTTP Error: ".concat(response.status, " ").concat(response.statusText));
        case 7:
          $('.title-control').hide(); // Hide map title so it doesn't overlap editor window
          _context4.next = 10;
          return response.data;
        case 10:
          view = _context4.sent;
          $editDiv = $('<div/>').addClass('mapObj-popup').html(view);
          L.DomEvent.disableClickPropagation($editDiv[0]);
          L.DomEvent.disableScrollPropagation($editDiv[0]);
          L.popup({
            offset: L.point(0, -30)
          }).setLatLng(props.center).setContent($editDiv[0]).openOn(map);
          $($editDiv).find('.obj-color.color-picker').spectrum(_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.setColorPicker('color'));
          $($editDiv).find('.obj-fill.color-picker').spectrum(_objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.setColorPicker('fillColor'));
        case 17:
        case "end":
          return _context4.stop();
      }
    }, _callee4);
  }));
  return _showEditPopup.apply(this, arguments);
}
function updateHiddenFields(props) {
  var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)();
  var type = props.type;
  var mapId = $("#mapForm").find("#Id").val();
  $('.obj-mapId').val(mapId);
  console.log('updateHiddenFields props', props, 'layer', layer);
  if (type.toLowerCase() == 'point') {
    var latlng = layer.getLatLng();
    $('.obj-lat').val(latlng.lat);
    $('.obj-lng').val(latlng.lng);
  } else if (type.toLowerCase() == 'circle') {
    $('.obj-lat').val(props.center.lat);
    $('.obj-lng').val(props.center.lng);
    $('.obj-radius').val(props.radius);
  } else if (type.toLowerCase() === 'line') {
    var latlngs = layer.getLatLngs();
    var coordString = latlngs.map(function (p) {
      return "".concat(p.lng, " ").concat(p.lat);
    }).join(', ');
    var wkt = "LINESTRING(".concat(coordString, ")");
    $('.obj-geomWKT').val(wkt);
  } else if (type.toLowerCase() == 'polygon') {
    var _latlngs$;
    var _latlngs = layer.getLatLngs();
    var or = (_latlngs$ = _latlngs[0]) !== null && _latlngs$ !== void 0 ? _latlngs$ : _latlngs; // outer ring
    var closed = _toConsumableArray(or);

    // close the ring
    if (or.length > 0 && (or[0].lat !== or[or.length - 1].lat || or[0].lng !== or[or.length - 1].lng)) {
      closed.push(or[0]);
    }
    var _coordString = closed.map(function (p) {
      return "".concat(p.lng, " ").concat(p.lat);
    }).join(', ');
    var _wkt = "POLYGON((".concat(_coordString, "))");
    $('.obj-geomWKT').val(_wkt);
  }
}

// Delete
function onDelete(_x5, _x6) {
  return _onDelete.apply(this, arguments);
}
function _onDelete() {
  _onDelete = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee5(id, type) {
    var response;
    return _regeneratorRuntime().wrap(function _callee5$(_context5) {
      while (1) switch (_context5.prev = _context5.next) {
        case 0:
          _context5.next = 2;
          return _utilities_api_js__WEBPACK_IMPORTED_MODULE_3__["default"].postForm("".concat(urlBase, "DeleteObject/"), {
            id: id,
            objType: type
          });
        case 2:
          response = _context5.sent;
          console.log('onDelete response', response);
          if (response.success == true) {
            console.log('onDelete curLayer', (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)());
            (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.deleteActive)();
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
  setFormListeners: function setFormListeners(formId) {
    $(formId).on('submit', function (event) {
      event.preventDefault();
      mapFormUtil.onSubmitForm(formId); // submit form
    });
    $(formId).find('.draw-list li').off('click').on('click', function () {
      var type = $(this).data('type');
    });
    $(document).off('click', formId + ' .btn-red').on('click', formId + ' .btn-red', function () {
      var id = $(formId).data('id');
      var type = $(formId).data('obj');
      onDelete(id, type);
    });
    _utilities_form_js__WEBPACK_IMPORTED_MODULE_4__.formUtil.setListeners(formId);
    if (formId == '#mapObjForm') {
      _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.setStyleListeners('#mapObjForm');
    }
  },
  onSubmitForm: function () {
    var _onSubmitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(formId) {
      var $form, isCreate, response, newName, objType, action;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            $form = $(formId);
            isCreate = $form.attr('action').includes('Create');
            _context.next = 4;
            return _utilities_form_js__WEBPACK_IMPORTED_MODULE_4__.formUtil.submitForm(formId);
          case 4:
            response = _context.sent;
            console.log('mapUtil onSubmitForm response', response);
            if (response && response.success) {
              // Update map title if user edited name
              if (formId == '#mapForm') {
                newName = $('#mapForm #Name').val();
                $('.map-info').toggleClass('d-none');
                $('.map-title').text(newName);
              } else {
                map.off('popupclose', _objStyleUtil_js__WEBPACK_IMPORTED_MODULE_2__.restoreStyle); // Cancel event listeners to reset/delete
                map.off('popupclose', _mapState_js__WEBPACK_IMPORTED_MODULE_0__.deleteActive);
                map.closePopup();
                objType = $form.data('obj');
                action = isCreate ? 'Created' : 'Updated';
                if (isCreate && response.data) {
                  mapFormUtil.updateId(response.data, $form.data('obj'));
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
          case 7:
          case "end":
            return _context.stop();
        }
      }, _callee);
    }));
    function onSubmitForm(_x7) {
      return _onSubmitForm.apply(this, arguments);
    }
    return onSubmitForm;
  }(),
  updateId: function updateId(data, type) {
    var layer = (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.getActive)();
    var id = data.properties.id;
    layer.feature.properties.id = id;
    console.log('updateId layer', layer, 'id', id, 'data', data);
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.deleteIndex)(-1);
    (0,_mapState_js__WEBPACK_IMPORTED_MODULE_0__.setIndex)(id, layer);
  }
};

//export async function addObject(l, type) {
//    const objType = typeMap[e.type] ?? 'Polygon';
//    const layerSet = getLayerset(type);

//    console.log('layerset', layerSet, 'layer', l, 'type', type);

//    layerProps["name"] = 'New ' + objType;

//    if (type === 'circle') {
//        addCircle(l, layerSet);
//    }
//    else {
//        const geojson = l.toGeoJSON();
//        geojson.properties = layerProps;
//        layerSet.addData(geojson);
//    }

//    setActive(getLastLayer(layerSet));

//    setIndex(-1, getActive());

//    const props = {
//        id: -1,
//        type: type,
//        data: { objType: type },
//        url: `${urlBase}LoadCreateObject/`,
//        center: (type == 'Point' || type == 'Circle') ? l.getLatLng() : l.getBounds().getCenter(),
//    }

//    _style.saveStyle();

//    await showEditPopup(props).then(() => {
//        mapFormUtil.setFormListeners('#mapObjForm');

//        updateHiddenFields(type, layerProps);
//        map.on('popupclose', deleteActive);
//    });
//}

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
$(function () {

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
  setListeners: function setListeners(formId) {
    $form = $(document).find($(formId));
    if ($.validator && $.validator.unobtrusive) {
      $.validator.unobtrusive.parse($form);
    }

    //console.log('setListeners form', $form, 'action', $form.attr('action'));
    if ($form.attr('action').includes('Edit')) {
      formUtil.setModelChanges();
    }
    formUtil.showHideBtns(formId);
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
    var _submitForm = _asyncToGenerator(/*#__PURE__*/_regeneratorRuntime().mark(function _callee(formId) {
      var action;
      return _regeneratorRuntime().wrap(function _callee$(_context) {
        while (1) switch (_context.prev = _context.next) {
          case 0:
            $form = $(formId);
            console.log('formUtil submitForm $form', $form);
            action = $form.attr('action');
            console.log('formUtil submitForm changes', Changes, 'action', action);
            if (!$form.valid()) {
              _context.next = 10;
              break;
            }
            _context.next = 7;
            return _api_js__WEBPACK_IMPORTED_MODULE_0__["default"].postForm(action, $form.serialize());
          case 7:
            return _context.abrupt("return", _context.sent);
          case 10:
            if (!(action.includes('Create') && !$form.valid())) {
              _context.next = 14;
              break;
            }
            return _context.abrupt("return", {
              success: false,
              error: 'Invalid form'
            });
          case 14:
            if (!(Changes.length == 0)) {
              _context.next = 16;
              break;
            }
            return _context.abrupt("return", {
              success: true
            });
          case 16:
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
  showHideBtns: function showHideBtns(formId) {
    $form = $(formId);
    $(formId).find('button.toggle-edit').on('click', function () {
      var model = $(this).parents('.model');
      model.find('.m-toggle').toggleClass('d-none');
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
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	__webpack_require__("./wwwroot/js/location/location.js");
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__("./wwwroot/js/map/map.js");
/******/ 	
/******/ })()
;
//# sourceMappingURL=location.bundle.js.map