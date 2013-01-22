var MockObject = function () {
	this.initialize && this.initialize();
};


var extend = function (protoProps, staticProps) {
	var parent = this,
	    child,
	    Surrogate;

	if (protoProps && _.has(protoProps, 'constructor')) {
		child = protoProps.constructor;
	} else {
		child = function() { return parent.apply(this, arguments); };
	}

	_.extend(child, parent, staticProps);

	Surrogate = function() { this.constructor = child; };
	Surrogate.prototype = parent.prototype;
	child.prototype = new Surrogate;

	if (protoProps) {
		_.extend(child.prototype, protoProps);
	}

	child.__super__ = parent.prototype;

	return child;
};

MockObject.extend = extend;



var MockContext = MockObject.extend({
	initialize: function () {
		this.audit = new MockAudit();
		this.template = new MockTemplate();
		this.helper = new MockHelper();
		this.logger = new MockLogger();
	},
	
	get_audit: function () {
		return this.audit;
	},
	
	get_template: function () {
		return this.template;
	},
	
	get_helper: function () {
		return this.helper;
	},
	
	get_logger: function (message) {
		return this.logger;
	}
});



var MockAudit = MockObject.extend({
	GetSignature: function() {
		return {
			get_Content: function () {
			}
		};
	}
});



var MockTemplate = MockObject.extend({
	initialize: function () {
		this.data = { };
	},
	
	get: function (name) {
		return this.data[name];
	},
	
	put: function (name, value) {
		this.data[name] = value;
	}
});




var MockHelper = MockObject.extend({
	GetImageSrc: function () {
		return "MockImageSource";
	}
});


var MockLogger = MockObject.extend({
	initialize: function () {
		this._log = [];	
	},
	
	log: function (message) {
//		if (typeof message !== "string") {
//			throw new Exception("Only strings are allowed to be passed to the logger.log method.");
//		}
		this._log.unshift(message);
	},
	
	getLog: function () {
		return this._log;
	}
});