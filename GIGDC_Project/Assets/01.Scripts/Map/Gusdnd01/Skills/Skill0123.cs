using UnityEngine;

public class Skill0123 : SkillBase {
	protected override void Reset(){
		skillIndex = 8;
	}
 
	public override void Skill(){
		if(!isLocked){
			//스킬 내용 구성 적어주고
			btn.interactable = true;
		}
		else{
			btn.interactable = false;
		}
	}
}
