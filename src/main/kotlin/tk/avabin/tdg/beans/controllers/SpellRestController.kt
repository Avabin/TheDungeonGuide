package tk.avabin.tdg.beans.controllers

import org.modelmapper.ModelMapper
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.http.HttpStatus
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.PathVariable
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod
import org.springframework.web.bind.annotation.RestController
import tk.avabin.tdg.beans.dtos.SpellDto
import tk.avabin.tdg.beans.entities.Spell
import tk.avabin.tdg.beans.services.entities.SpellService

@RestController
@RequestMapping("/spell")
class SpellRestController(
        private @Autowired val spellService: SpellService,
        private @Autowired val modelMapper: ModelMapper
) {

    @RequestMapping(value = "/add", method = arrayOf(RequestMethod.POST))
    fun addSpell(@RequestBody spellDto: SpellDto): ResponseEntity<SpellDto> {
        var mapped = modelMapper.map(spellDto, Spell::class.java)
        return if (!spellService.contains(mapped.name)) {
            mapped = spellService.saveOrUpdate(mapped)
            ResponseEntity(modelMapper.map(mapped, SpellDto::class.java), HttpStatus.CREATED)
        } else {
            mapped = spellService.getByName(mapped.name)
            ResponseEntity(modelMapper.map(mapped, SpellDto::class.java), HttpStatus.UNPROCESSABLE_ENTITY)
        }
    }

    @RequestMapping(value = "/get/{name}")
    fun getSpellByName(@PathVariable name: String): ResponseEntity<SpellDto> {
        return try {
            ResponseEntity(
                    modelMapper.map(spellService.getByName(name),
                            SpellDto::class.java), HttpStatus.OK
            )
        } catch (e: Exception) {
            ResponseEntity(HttpStatus.NOT_FOUND)
        }
    }

    @RequestMapping(value = "/get/{id}/id")
    fun getSpellById(@PathVariable id: Int): ResponseEntity<SpellDto> {
        return try {
            ResponseEntity(
                    modelMapper.map(spellService.getById(id),
                            SpellDto::class.java), HttpStatus.OK
            )
        } catch (e: Exception) {
            ResponseEntity(HttpStatus.NOT_FOUND)
        }
    }

    @RequestMapping(value = "/del/{name}", method = arrayOf(RequestMethod.DELETE))
    fun deleteSpell(@PathVariable name: String): ResponseEntity<Any> {
        return if (spellService.contains(name)) {
            spellService.delete(spellService.getByName(name))
            ResponseEntity(HttpStatus.OK)
        } else {
            ResponseEntity(HttpStatus.NOT_FOUND)
        }
    }
}