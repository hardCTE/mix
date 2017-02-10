
create table ljptsz
select * from
(
SELECT * from ljptsz50
union 
SELECT * from ljptsz5070
union 
SELECT * from ljptsz70p
) a



select count(*) from ljptsz
group by houseid
having count(*) > 1


select sum(c) from (
	SELECT count(*) c from ljptsz
	group by houseid
	having count(*) > 1
) a


select tag,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 1)),'/',1))) xiaoqu,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 2)),'/',1))) gj,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 3)),'/',1))) mj,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 4)),'/',1))) chaoxiang,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 5)),'/',1))) zhuangxiu,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 6)),'/',1))) dianti
from ljptsz


select tag,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 1)),'/',1))) xiaoqu,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 2)),'/',1))) gj,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 3)),'/',1))) mj,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 4)),'/',1))) chaoxiang,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 5)),'/',1))) zhuangxiu,
trim(reverse(substring_index(reverse(substring_index(tag, '/', 6)),'/',1))) dianti,
case (length('tag')-length(REPLACE('tag','/',''))) 
	when 6 then trim(reverse(substring_index(reverse(substring_index(tag, '/', 6)),'/',1)))
	else ''
END dianti2
from ljptsz


update ljptsz
set 
	quyu=trim(reverse(substring_index(reverse(substring_index(tag, '/', 1)),'/',1))),
	geju=trim(reverse(substring_index(reverse(substring_index(tag, '/', 2)),'/',1))),
	mianji= replace(trim(reverse(substring_index(reverse(substring_index(tag, '/', 3)),'/',1))),'平米',''),
	chaoxiang=trim(reverse(substring_index(reverse(substring_index(tag, '/', 4)),'/',1))),
	zhuangxiu=trim(reverse(substring_index(reverse(substring_index(tag, '/', 5)),'/',1))),
	dianti=trim(reverse(substring_index(reverse(substring_index(tag, '/', 6)),'/',1)))




update lj300
set 
url=trim(url),
title=trim(title),
subwaytag=trim(subwaytag),
taxfree=trim(taxfree),
haskey=trim(haskey),
hstype=trim(hstype),
tag=trim(tag)
	
update lj300
set 
quyu=trim(reverse(substring_index(reverse(substring_index(tag, '/', 1)),'/',1))),
geju=trim(reverse(substring_index(reverse(substring_index(tag, '/', 2)),'/',1))),
mianji= replace(trim(reverse(substring_index(reverse(substring_index(tag, '/', 3)),'/',1))),'平米',''),
chaoxiang=trim(reverse(substring_index(reverse(substring_index(tag, '/', 4)),'/',1))),
zhuangxiu=trim(reverse(substring_index(reverse(substring_index(tag, '/', 5)),'/',1))),
dianti=case (length('tag')-length(REPLACE('tag','/',''))) 
	when 6 then trim(reverse(substring_index(reverse(substring_index(tag, '/', 6)),'/',1)))
	else ''
END



~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

select * from ljptsz
where 
(subwaytag is null or subwaytag<>'不限购') and (taxfree is null or taxfree<>'不限购') and (haskey is null or haskey<>'不限购') and (hstype is null or (hstype<>'不限购' and hstype<>' 不限购'))
and price < 150
and quyu <> '燕郊' and quyu<>'燕郊城区'
and INSTR(title,'车位')=0
and INSTR(title,'不限购')=0
and INSTR(title,'地下一层')=0
and INSTR(title,'商住两用')=0
and INSTR(title,'底商')=0
and INSTR(title,'熙旺中心')=0
and INSTR(title,'旭辉E天地')=0
and INSTR(title,'国融国际')=0
and INSTR(title,'东亚五环国际')=0
and INSTR(title,'东亚首航国际')=0
and houseid not in(101100885270,101100810892,101101036394,101091828255,101100375153,101100375166,101100989630,101101115313,101100995134,101100933635,101091062879,101100809836,
101100809836,
)


// 非商住

SELECT * from ljptsz
where price < 150
and mianji >50
and (subwaytag is null or subwaytag<>'不限购') and (taxfree is null or taxfree<>'不限购') and (haskey is null or haskey<>'不限购') and (hstype is null or (hstype<>'不限购' and hstype<>' 不限购'))
and quyu <> '燕郊' and quyu<>'燕郊城区'
and INSTR(title,'车位')=0
and INSTR(title,'不限购')=0
and INSTR(title,'地下一层')=0
and INSTR(title,'商住两用')=0
and INSTR(title,'底商')=0
and INSTR(title,'熙旺中心')=0
and INSTR(title,'旭辉E天地')=0
and INSTR(title,'国融国际')=0
and INSTR(title,'东亚五环国际')=0
and INSTR(title,'东亚首航国际')=0
and INSTR(title,'i立方')=0
and INSTR(title,'绿地启航社')=0
and INSTR(title,'琥珀郡')=0 
and houseid not in(101100885270,101100810892,101101036394,101091828255,101100375153,101100375166,101100989630,101101115313,101100995134,101100933635,101091062879,101100809836,
101100809836
)


SELECT * from lj300
where price < 150
and mianji >50
and (subwaytag is null or subwaytag<>'不限购') and (taxfree is null or taxfree<>'不限购') and (haskey is null or haskey<>'不限购') and (hstype is null or (hstype<>'不限购' and hstype<>' 不限购'))
and quyu <> '燕郊' and quyu<>'燕郊城区'
and INSTR(title,'车位')=0
and INSTR(title,'不限购')=0
and INSTR(title,'地下一层')=0
and INSTR(title,'地下室')=0
and INSTR(title,'商住两用')=0
and INSTR(title,'底商')=0
and INSTR(title,'熙旺中心')=0
and INSTR(title,'旭辉E天地')=0
and INSTR(title,'国融国际')=0
and INSTR(title,'东亚五环国际')=0
and INSTR(title,'东亚首航国际')=0
and INSTR(title,'i立方')=0
and INSTR(title,'绿地启航社')=0
and INSTR(title,'琥珀郡')=0
and INSTR(title,'锋创科技园')=0

and houseid not in(101100885270,101100810892,101101036394,101091828255,101100375153,101100375166,101100989630,101101115313,101100995134,101100933635,101091062879,101100809836,
101100809836,101101129456
)


