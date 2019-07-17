Object = {};
Object.__index = Object;
function Object:SubClass(className)
	_G[className] = {};
	local class = _G[className];
	class.__index = class;
	class.Base = self;
	setmetatable(class,self);
	return class;
end
function Object:new()
	local obj = {};
	setmetatable(obj,self);
	self:Init();
	return obj;
end
function Object:Init()
end


--[[    使用说明
Object:SubClass("Person") --新建类
function Person:f1()      --添加函数
 	print("biu");
end 
Person:SubClass("Man")    --继承类
function Man:f1()         --重写函数
 	print("piu");
end 
Man.Base.f1();            --调父类函数
---------构造的使用
Object:SubClass("Person");
function Person:Init()
	Person.Base:Init();
	print(2);
end
Person:SubClass("man");
a = man:new();
]]--