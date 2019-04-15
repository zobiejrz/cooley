import random
import pandas as pd
class Character:
	"""Stores and edits character data."""
	
	# Page 1
	name = "default"
	cla = []
	background = ""
	race = "default"
	align = "default"
	xp = 0
	
	armor_class = 0
	initiative = 0
	speed = 0

	personality_traits = ["none"]
	ideals = ["none"]
	bonds = ["none"]
	flaws = ["none"]

	max_hp = 0
	current_hp = 0
	temp_hp = 0
	hit_dice = [0, "D6"]
	death_saves_success = 0
	death_saves_failure = 0

	attacks = []

	proficiency_bonus = 0
	inspiration = 0

	abilities = {"Strength": [0,0,0],
				 "Dexterity": [0,0,0],
				 "Constitution": [0,0,0],
				 "Intelligence": [0,0,0],
				 "Wisdom": [0,0,0],
				 "Charisma": [0,0,0]}

	skills = {"Acrobatics": 0,
			  "Animal handling": 0,
			  "Arcana": 0,
			  "Athletics": 0,
			  "Deception": 0,
			  "History": 0,
			  "Insight": 0,
			  "Intimidation": 0,
			  "Investigation": 0,
			  "Medicine": 0,
			  "Nature": 0,
			  "Perception": 0,
			  "Performance": 0,
			  "Persuasion": 0,
			  "Religion": 0,
			  "Sleight of Hand": 0,
			  "Stealth": 0,
			  "Survival": 0}

	passive_wisdom = 0

	other_proficiences_languages = []

	wallet = {"Copper Point": 0,
			  "Silver Point": 0,
			  "Electrum Point": 0,
			  "Gold Point": 0,
			  "Platinum Point": 0}

	equipment = []
	features_traits = []

	# Page 2
	allies_organizations = ["none"]
	age = 0
	height = 0
	weight = 0
	hair = ""
	skin = ""
	eyes = ""
	character_appearance = ""
	character_backstory = ""
	more_features_traits = ["none"]
	treasure = ["none"]

	# Page 3
	spellcasting_class = ""
	spellcasting_ability = ""
	spell_save_DC = 0
	spell_attack_bonus = 0
	spell_slots = 0
	spell_slots_used = 0
	cantrips = []
	spellbook = [[[]]]

	def __init__(self):
		"""init default variables"""
		

	# def roll(self, num):
	# 	"""picks a number between 1 and num"""
	# 	a = random.randint(1,num)
	# 	print(a)
	# 	return a

	def disp_basic_stats(self):
		"""Name, Class, Alignment, Background, XP, Armor Class, HP"""
		print("{}, {}xp".format(self.name,self.xp))
		print("HP: {}(max) + {}(temp)/{}".format(self.current_hp, self.temp_hp, self.max_hp))
		print("Armor Class: {}".format(self.armor_class))
		print("~~CLASSES~~")
		for x in range(0, len(self.cla)):
			print("{}: {}, {}".format(x+1, self.cla[x][0], self.cla[x][1]))

	def disp_skills(self):
		"""Skills"""
		df = pd.DataFrame.from_dict(data=self.skills, orient='index')
		df.columns = ['']
		print ("{}\n".format(df))

	def disp_abilities(self):
		"""Ability Scores, Modifiers, and Saving Throws"""
		df = pd.DataFrame.from_dict(data=self.abilities, orient='index')
		df.columns = ['Score', 'Modifier', 'Saving']
		print ("{}\n".format(df))

	def disp_class(self):
		"""Display Classes"""
		for x in range(0, len(self.cla)):
			print("{}: {}, {}".format(x+1, self.cla[x][0], self.cla[x][1]))

	def add_class(self, name, level):
		"""Add a class to cla"""
		self.cla.append([name, level])

	def del_class(self, num):
		"""delete a class from cla"""
		del self.cla[num-1]

	def edit_class_lvl(self, num, new_level):
		"""change level of a class in cla"""
		self.cla[num-1][1] = new_level

	def disp_wallet(self):
		"""prints balance"""
		df = pd.DataFrame.from_dict(data=self.wallet, orient='index')
		df.columns = ['Balance']
		print ("{}\n".format(df))
		
	def edit_wallet(self, plat, gold, elec, silv, copp):
		"""edits balance (handles negatives)"""
		self.wallet["Copper Point"] += copp
		self.wallet["Silver Point"] += silv
		self.wallet["Electrum Point"] += elec
		self.wallet["Gold Point"] += gold
		self.wallet["Platinum Point"] += plat

	def disp_attacks(self):
		"""Prints Attacks from attacks"""
		alen = len(self.attacks)
		if alen > 3:
			print("WARNING: THERE ARE MORE THAN 3 ATTACKS")

		for x in range(0, alen):
			print("{}: {} / {} / {}".format(x + 1, self.attacks[x][0], self.attacks[x][1], self.attacks[x][2]))

	def add_attacks(self, name, bonus, damage):
		"""Adds Attack to attacks"""
		self.attacks.append([name, bonus, damage])

	def edit_attacks(self, slot, name, bonus, damage):
		"""Edit Attacks"""
		self.attacks[slot] = [name, bonus, damage]
	
	def del_attacks(self, num):
		"""Removes attack from attacks at index slot"""
		del self.attacks[num - 1]
	
	def add_xp(self, num):
		"""Add to current xp number"""
		self.xp += num
	
	def change_xp(self, num):
		"""Change xp number"""
		self.xp = num

	def change_temp_hp(self, num):
		"""changes temporary hp"""
		self.temp_hp = num
	
	def edit_equipment(self, num, name, notes):
		"""Edits equipment and index num with name and notes"""
		self.equipment[num] = [name, notes]

	def disp_equipment(self):
		"""Displays all items in equipment"""
		elen = len (self.equipment)
		for x in range(0, elen):
			print("{}: {} - {}".format(x + 1, self.equipment[x][0], self.equipment[x][1]))

	def add_equipment(self, name, notes):
		"""Adds anything to equipment"""
		self.equipment.append([name, notes])

	def del_equipment(self, num):
		"""delete from equipment at position num-1"""
		del self.equipment[num-1]


	def disp_spellbook(self):
		"""prints spellbook, cantrips, spell_slots (page 3)"""
		print("Spell Slots: {} / {}".format(self.spell_slots_used, self.spell_slots))

		self.disp_cantrips()
		self.disp_spell()
		

	def disp_spell(self):
		"""prints only spells"""
		print("~~~ Spells ~~~")
		slen  = len(self.spellbook)
		for x in range(0, slen):
			llen = len(self.spellbook[x])
			print ("Level {}".format(x + 1))
			for y in range(0, llen):
				print("{}: {} - {}".format(y + 1, self.spellbook[x][y][0], self.spellbook[x][y][1]))

	# def del_spell(self, lvl, num):
	# 	"""removes spell from spellbook at index [lvl][num]"""
	# 	del self.spellbook[lvl - 1][num - 1]

	# def add_spell(self, lvl, name, notes):
	# 	"""adds spell to spellbook"""
	# 	self.spellbook[lvl - 1].append = [name, notes]

	# def edit_spell(self, lvl, num, name, notes):
	# 	"""Edits spell in at index [lvl][num]"""
	# 	self.spellbook[lvl - 1][num] = [name, notes]

	def edit_cantrips(self, num, name, notes):
		"""edits cantrip at index num - 1"""
		self.cantrips[num - 1] = [name, notes]

	def del_cantrips(self, num):
		"""removes cantrip at index num - 1"""
		del self.cantrips[num - 1]

	def add_cantrips(self, name, notes):
		"""adds cantrip at index num + 1"""
		self.cantrips.append([name,notes])

	def disp_cantrips(self):
		"""Prints all cantrips"""
		clen = len( self.cantrips )
		print('~~~Cantrips~~~')
		for x in range(0, clen):
			print("{}: {} - {}".format(x + 1, self.cantrips[x][0], self.cantrips[x][1]))

	# def update_variables(self):
	# 	"""make sure skill atributes are updated with proficiency bonus"""

	def dictionary_all_variables(self):
		"""Returns a dictionary containing all character data"""
