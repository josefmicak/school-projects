import pygame
import numpy as np
from my_object import My_Object


class Reaper(My_Object):
    def __init__(self, screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x=None,y=None):
        super().__init__(screen_width, screen_height, left_offset, right_offset, down_offset, direction, action, image_id, health, type, x, y)
        self.x = x
        self.y = y
        self.type = type
        self.left_offset = left_offset
        self.right_offset = right_offset
        self.down_offset = down_offset
        self.action = action
        self.image_id = image_id
        self.direction = direction
        self.health = health
        self.img = pygame.image.load('reaper_3/Idle/0_Reaper_Man_Idle Blinking_000.png')

    def show(self, game_display):
            game_display.blit(self.img, (self.x, self.y))

    def get_height(self):
        return self.img.get_height()

    def get_width(self):
        return self.img.get_width()

    def update_image(self):
        if self.action == 'Walking':
            if self.image_id < 10:
                path = 'reaper_3/Walking/0_Reaper_Man_Walking_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Walking/0_Reaper_Man_Walking_0' + str(self.image_id) + '.png'
        elif self.action == 'Walking_left':
            if self.image_id < 10:
                path = 'reaper_3/Walking_left/0_Reaper_Man_Walking_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Walking_left/0_Reaper_Man_Walking_0' + str(self.image_id) + '.png'
        if self.action == 'Attacking':
            if self.image_id < 10:
                path = 'reaper_3/Attacking/0_Reaper_Man_Slashing_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Attacking/0_Reaper_Man_Slashing_0' + str(self.image_id) + '.png'
        elif self.action == 'Attacking_left':
            if self.image_id < 10:
                path = 'reaper_3/Attacking_left/0_Reaper_Man_Slashing_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Attacking_left/0_Reaper_Man_Slashing_0' + str(self.image_id) + '.png'
        elif self.action == 'Hurt':
            if self.image_id < 10:
                path = 'reaper_3/Hurt/0_Reaper_Man_Hurt_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Hurt/0_Reaper_Man_Hurt_0' + str(self.image_id) + '.png'
        elif self.action == 'Dying':
            if self.image_id < 10:
                path = 'reaper_3/Dying/0_Reaper_Man_Dying_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Dying/0_Reaper_Man_Dying_0' + str(self.image_id) + '.png'
        elif self.action == 'Idle':
            if self.image_id < 10:
                path = 'reaper_3/Idle/0_Reaper_Man_Idle Blinking_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Idle/0_Reaper_Man_Idle Blinking_0' + str(self.image_id) + '.png'
        elif self.action == 'Idle_left':
            if self.image_id < 10:
                path = 'reaper_3/Idle_left/0_Reaper_Man_Idle Blinking_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Idle_left/0_Reaper_Man_Idle Blinking_0' + str(self.image_id) + '.png'
        elif self.action == 'Running':
            if self.image_id < 10:
                path = 'reaper_3/Running/0_Reaper_Man_Running_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Running/0_Reaper_Man_Running_0' + str(self.image_id) + '.png'
        elif self.action == 'Running_left':
            if self.image_id < 10:
                path = 'reaper_3/Running_left/0_Reaper_Man_Running_00' + str(self.image_id) + '.png'
            else:
                path = 'reaper_3/Running_left/0_Reaper_Man_Running_0' + str(self.image_id) + '.png'
        self.img = pygame.image.load(path)